using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Upgrade
    public GameObject rangePanel;
    public GameObject sellPanel;
    public GameObject upgradePanel;
    private float cost = GameConstant.PriceTower;
    private float sellRate = GameConstant.SellFactor;



    private int flag = 0;
    // 塔编号
    public int towerIndex;
    // 塔等级
    public int towerLevel;
    // 注意：先乘后加，避免除以0问题
    // 建筑是否用电（自动判断）
    private bool consumesPower;
    // 建筑血量（改用HPManager）
    // public float health;
    // 无电力时建筑范围
    private float range;
    // 电力范围加成因数（>1，下同）
    public float rangeBoostFactor;
    // 电力范围加成常数
    public float rangeBoostConstant;
    // 实际范围
    public float rangeReal;
    // 无电力时建筑攻速 (发/秒)
    private float shootSpeed;
    // 攻速计时器
    private float shootTimer;
    // 电力射速加成因数
    public float shootSpeedBoostFactor;
    // 电力射速加成常数
    public float shootSpeedBoostConstant;
    // 实际攻速
    public float shootSpeedReal;
    // 无电力时建筑转速
    private float rotateSpeed;
    // 电力转速加成因数
    public float rotateSpeedBoostFactor;
    // 电力转速加成常数
    public float rotateSpeedBoostConstant;
    // 实际转速
    public float rotateSpeedReal;
    // 实际获取电量
    public float powerGet;
    // 建筑电力消耗量
    private float powerConsumption;
    // [0, 1] 的数字，代表是否满电
    private float powerPercentage;
    // 建筑子弹速度（弃用）
    // public float bulletSpeed;
    // 建筑攻击力（弃用）
    // public float damage;
    // 敌人存储
    public GameObject[] enemies;
    // 基地存储
    public GameObject homeOrBase;
    // 索敌间隔（弃用）
    // public float enemyIntervalTime;
    // 从敌人指向基地的向量
    public Vector3[] enemyToBase;
    // 从敌人指向塔（自己）的向量
    public Vector3[] enemyToTower;
    // 敌人是否在范围内
    bool[] enemyWithinRange;
    // 敌人与基地的距离（即enemyToBase取模）
    float[] distanceEnemyBase;
    // 最近范围内敌人到基地距离的敌人编号（0开始）
    int minValidEnemyBaseDistanceIndex = 0;
    // 攻速的倒数，用于比较时间
    float shootInterval;
    // 打出的子弹
    // 伤害等由子弹自身决定，因此要选取正确的子弹
    public GameObject bullet;
    // 如果实际瞄准方向与应瞄准方向小于这个值，开始发射子弹。（数学近似有问题）
    // 不要填0！
    // DO NOT PUT "ZERO" HERE！
    public float angleDelta;

    void Start()
    {
        powerConsumption = GameConstant.towerPowerConsumption[towerIndex, towerLevel];
        range = GameConstant.towerRange[towerIndex, towerLevel];
        rotateSpeed = GameConstant.towerRotateSpeed[towerIndex, towerLevel];
        shootSpeed = GameConstant.towerShootSpeed[towerIndex, towerLevel];
        if (powerConsumption > 0)
        {
            consumesPower = true;
        }
        else
        {
            consumesPower = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (consumesPower == true)
        {
            // 电量百分比
            powerPercentage = Mathf.Max(powerGet / powerConsumption, 1f);
            // 真实范围计算
            rangeReal = range * (1 + (rangeBoostFactor - 1) * powerPercentage) + rangeBoostConstant * powerPercentage;
            // 真实攻速计算
            shootSpeedReal = shootSpeed * (1 + (shootSpeedBoostFactor - 1) * powerPercentage) + shootSpeedBoostConstant * powerPercentage;
            // 真实转速计算
            rotateSpeedReal = rotateSpeed * (1 + (rotateSpeedBoostFactor - 1) * powerPercentage) + rotateSpeedBoostConstant * powerPercentage;
        }
        else
        {
            rangeReal = range;
            shootSpeedReal = shootSpeed;
            rotateSpeedReal = rotateSpeed;
        }
        rangePanel.transform.localScale = new Vector3(2f * rangeReal, 2f * rangeReal, 1f);
        // 填弹
        shootTimer += Time.deltaTime;
        shootInterval = 1 / shootSpeedReal;
        // 找到所有敌人，放在组enemies中
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // 对每个敌人计算
        enemyToBase = new Vector3[enemies.Length];
        enemyToTower = new Vector3[enemies.Length];
        enemyWithinRange = new bool[enemies.Length];
        distanceEnemyBase = new float[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            // 敌人到基地向量
            enemyToBase[i] = homeOrBase.transform.position - enemies[i].transform.position;
            // 敌人到塔向量
            enemyToTower[i] = transform.position - enemies[i].transform.position;
            // 检测敌人是否在塔内部
            if (enemyToTower[i].magnitude <= rangeReal)
            {
                enemyWithinRange[i] = true;
                // 记录敌人与基地距离
                distanceEnemyBase[i] = enemyToBase[i].magnitude;
            }
            else
            {
                enemyWithinRange[i] = false;
                // 记录敌人与基地距离为极大值（无效）
                distanceEnemyBase[i] = Mathf.Infinity;
            }
        }
        // 防止默认索敌索0号敌人
        bool foundEnemy = false;
        minValidEnemyBaseDistanceIndex = 0;
        // 每个敌人以“打擂台”判断最接近基地
        for (int i = 0;i < enemies.Length;i++)
        {
            if (enemyWithinRange[i] == true)
            {
                foundEnemy = true;
            }
            if (distanceEnemyBase[i] < distanceEnemyBase[minValidEnemyBaseDistanceIndex] && enemyWithinRange[i] == true)
            {
                minValidEnemyBaseDistanceIndex = i;
            }
        }
        // 索到敌人
        if (foundEnemy)
        {
            // 以最大转速向敌人旋转
            // 逆时针
            Vector3 direction = new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180), 0f);
            if (Vector3.Dot(direction, -enemyToTower[minValidEnemyBaseDistanceIndex]) < 0)
            {
                if (Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f < 0)
                {
                    transform.Rotate(0f, 0f, Mathf.Max(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeedReal), Space.Self);
                }
                else
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, -Time.deltaTime * rotateSpeedReal), Space.Self);
                }
            }
            else
            {
                // 逆时针
                if (Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f > 0)
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeedReal), Space.Self);
                }
                // 顺时针
                else
                {
                    transform.Rotate(0f, 0f, Mathf.Max(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, -Time.deltaTime * rotateSpeedReal), Space.Self);
                }
            }
        }
        if (foundEnemy && (Mathf.Abs(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f) <= angleDelta))
        {
            if (shootTimer >= shootInterval)
            {
                shootTimer = 0;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.25f), transform.rotation);
    }


    

    private void OnMouseDown()
    {
        if (flag % 2 == 0)
        {
            sellPanel.SetActive(true);
            rangePanel.SetActive(true);

            //feature.SetActive(true);
        }
        else if (flag % 2 == 1)
        {
            sellPanel.SetActive(false);
            rangePanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag++;
    }
}