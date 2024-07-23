using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TowerController : MonoBehaviour
{
    // UI相关
    public GameObject rangePanel;
    public GameObject sellPanel;
    public GameObject upgradePanel;
    private Light2D lightComponent;
    public Light2D lightRange;
    // 卖出钱比例
    private float sellRate = GameConstant.SellFactor;

    // 血量管理
    public HPManagement scriptHPManagement;

    // 底座
    public GameObject basePart;

    // 游戏内时间
    public float dayTime;
    // 是否夜晚
    private bool isNight;


    // 塔编号
    public int towerIndex;
    // 塔等级
    public int towerLevel = 1;

    // 建筑是否用电（自动判断）
    private bool consumesPower;

    // 建筑血量（改用HPManager）
    // public float health;

    // 注意：电力加成先乘后加，最后乘夜晚范围因数，避免除以0问题
    // 无电力时建筑范围
    private float range;
    // 电力范围加成因数（>1，下同）
    public float rangeBoostFactor;
    // 电力范围加成常数
    public float rangeBoostConstant;
    // 夜晚范围因数
    public float rangeNightFactor;
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
    // 实际攻速的倒数，用于比较时间
    private float shootInterval;

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
    private float powerPercentage;

    // 建筑子弹速度（弃用）
    // public float bulletSpeed;

    // 建筑攻击力（弃用）
    // public float damage;

    // 敌人存储
    public GameObject[] enemies;

    // 基地存储（自动调用tag为"Base"的游戏物体）
    private GameObject homeOrBase;

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

    // 使用的子弹列表
    // 伤害等由子弹自身决定，因此要选取正确的子弹
    /* 子弹索引规则：
     * 0开始，0、1、2分别对应1、2、3级无加成子弹
     * 3、4、5对应1、2、3级电力加成子弹（高伤低范围）
     */
    public GameObject[] bullets;
    // 如果实际瞄准方向与应瞄准方向小于这个值，开始发射子弹。（数学近似有问题）
    // 不要填0！
    // DO NOT PUT "ZERO" HERE！
    public float angleDelta;

    // 已在该塔上花费的钱（卖出时计算）
    private float currentCost;

    void Start()
    {
        homeOrBase = GameObject.FindWithTag("Base");
        rangeNightFactor = GameConstant.towerRangeNightFactor[towerIndex];
        lightComponent = GetComponent<Light2D>();
        powerConsumption = GameConstant.towerPowerConsumption[towerIndex, towerLevel - 1];
        GetPower();
    }

    // Update is called once per frame
    void Update()
    {
        if (dayTime != Clock.NowHour)
        {
            GetPower();
        }
        dayTime = Clock.NowHour;
        if (dayTime >= 6 && dayTime < 18)
        {
            isNight = false;
            lightComponent.intensity = 1f;
            lightRange.intensity = 0f;
        }
        else 
        {
            isNight = true;
            lightComponent.intensity = 1f;
            lightRange.intensity = 0.3f;
        }
        powerConsumption = GameConstant.towerPowerConsumption[towerIndex, towerLevel - 1];
        range = GameConstant.towerRange[towerIndex, towerLevel - 1];
        rotateSpeed = GameConstant.towerRotateSpeed[towerIndex, towerLevel - 1];
        shootSpeed = GameConstant.towerShootSpeed[towerIndex, towerLevel - 1];
        if (powerConsumption > 0)
        {
            consumesPower = true;
        }
        else
        {
            consumesPower = false;
        }
        if (consumesPower == true)
        {
            // 电量百分比
            powerPercentage = powerGet / powerConsumption;
            if (powerPercentage > 1f)
            {
                powerPercentage = 1;
            }
            // 真实范围计算
            // rangeReal = range * (1 + (rangeBoostFactor - 1) * powerPercentage) + rangeBoostConstant * powerPercentage;
            rangeReal = range * powerPercentage;
            // 真实攻速计算
            // shootSpeedReal = shootSpeed * (1 + (shootSpeedBoostFactor - 1) * powerPercentage) + shootSpeedBoostConstant * powerPercentage;
            shootSpeedReal = shootSpeed * powerPercentage;
            // 真实转速计算
            // rotateSpeedReal = rotateSpeed * (1 + (rotateSpeedBoostFactor - 1) * powerPercentage) + rotateSpeedBoostConstant * powerPercentage;
            rotateSpeedReal = rotateSpeed * powerPercentage;
        }
        else
        {
            rangeReal = range;
            shootSpeedReal = shootSpeed;
            rotateSpeedReal = rotateSpeed;
        }
        if (isNight)
        {
            rangeReal = rangeReal * rangeNightFactor;
        }
        rangePanel.transform.localScale = new Vector3(2f * rangeReal, 2f * rangeReal, 1f);
        lightComponent.pointLightOuterRadius = rangeReal;
        lightRange.pointLightOuterRadius = rangeReal;
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
        Instantiate(bullets[(int)(towerLevel - 1)], new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.25f), transform.rotation);
    }


    public void Sell()
    {
        sellPanel.SetActive(false);
        upgradePanel.SetActive(false);
        rangePanel.SetActive(false);
        currentCost = 0;
        for (int i = 0; i < towerLevel; i++)
        {
            currentCost += GameConstant.towerUpgradeCost[towerIndex, i];
        }
        GoldAndElectricity.gold += (int)(scriptHPManagement.HP / scriptHPManagement.MaxHP * currentCost * sellRate);
        Destroy(basePart);
    }
    public void Upgrade()
    {
        sellPanel.SetActive(false);
        upgradePanel.SetActive(false);
        rangePanel.SetActive(false);
        if (GoldAndElectricity.gold >= GameConstant.towerUpgradeCost[towerIndex, towerLevel] && Base.level > towerLevel)
        {
            GoldAndElectricity.gold -= (int)(GameConstant.towerUpgradeCost[towerIndex, towerLevel]);
            scriptHPManagement.SetHP(GameConstant.towerHealth[towerIndex, towerLevel]);
            towerLevel++;
            Debug.Log("Upgraded.");
        }
        else
        {
            Debug.Log("Failed.");
        }
    }
    private void GetPower()
    {
        if (GoldAndElectricity.electricity >= powerConsumption)
        {
            GoldAndElectricity.electricity -= powerConsumption;
            powerGet = powerConsumption;
        }
        else
        {
            powerGet = 0;
        }
        Debug.Log(powerGet);
    }
}