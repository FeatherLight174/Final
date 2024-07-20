using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject rangePanel;
    public GameObject sellPanel;
    private int flag = 0;
    // 建筑血量
    public float health;
    // 建筑范围
    public float range;
    // 建筑攻速 (发/秒)
    public float shootSpeed;
    // 攻速计时器
    float shootTimer;
    // 建筑转速
    public float rotateSpeed;
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

    }

    // Update is called once per frame
    void Update()
    {
        // 填弹
        shootTimer += Time.deltaTime;
        shootInterval = 1 / shootSpeed;
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
            if (enemyToTower[i].magnitude <= range)
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
                    transform.Rotate(0f, 0f, Mathf.Max(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeed), Space.Self);
                }
                else
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, -Time.deltaTime * rotateSpeed), Space.Self);
                }
            }
            else
            {
                // 逆时针
                if (Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f > 0)
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeed), Space.Self);
                }
                // 顺时针
                else
                {
                    transform.Rotate(0f, 0f, Mathf.Max(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, -Time.deltaTime * rotateSpeed), Space.Self);
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
        Debug.Log("Shoot!");
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
