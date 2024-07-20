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
    // �����
    public int towerIndex;
    // ���ȼ�
    public int towerLevel;
    // ע�⣺�ȳ˺�ӣ��������0����
    // �����Ƿ��õ磨�Զ��жϣ�
    private bool consumesPower;
    // ����Ѫ��������HPManager��
    // public float health;
    // �޵���ʱ������Χ
    private float range;
    // ������Χ�ӳ�������>1����ͬ��
    public float rangeBoostFactor;
    // ������Χ�ӳɳ���
    public float rangeBoostConstant;
    // ʵ�ʷ�Χ
    public float rangeReal;
    // �޵���ʱ�������� (��/��)
    private float shootSpeed;
    // ���ټ�ʱ��
    private float shootTimer;
    // �������ټӳ�����
    public float shootSpeedBoostFactor;
    // �������ټӳɳ���
    public float shootSpeedBoostConstant;
    // ʵ�ʹ���
    public float shootSpeedReal;
    // �޵���ʱ����ת��
    private float rotateSpeed;
    // ����ת�ټӳ�����
    public float rotateSpeedBoostFactor;
    // ����ת�ټӳɳ���
    public float rotateSpeedBoostConstant;
    // ʵ��ת��
    public float rotateSpeedReal;
    // ʵ�ʻ�ȡ����
    public float powerGet;
    // ��������������
    private float powerConsumption;
    // [0, 1] �����֣������Ƿ�����
    private float powerPercentage;
    // �����ӵ��ٶȣ����ã�
    // public float bulletSpeed;
    // ���������������ã�
    // public float damage;
    // ���˴洢
    public GameObject[] enemies;
    // ���ش洢
    public GameObject homeOrBase;
    // ���м�������ã�
    // public float enemyIntervalTime;
    // �ӵ���ָ����ص�����
    public Vector3[] enemyToBase;
    // �ӵ���ָ�������Լ���������
    public Vector3[] enemyToTower;
    // �����Ƿ��ڷ�Χ��
    bool[] enemyWithinRange;
    // ��������صľ��루��enemyToBaseȡģ��
    float[] distanceEnemyBase;
    // �����Χ�ڵ��˵����ؾ���ĵ��˱�ţ�0��ʼ��
    int minValidEnemyBaseDistanceIndex = 0;
    // ���ٵĵ��������ڱȽ�ʱ��
    float shootInterval;
    // ������ӵ�
    // �˺������ӵ�������������Ҫѡȡ��ȷ���ӵ�
    public GameObject bullet;
    // ���ʵ����׼������Ӧ��׼����С�����ֵ����ʼ�����ӵ�������ѧ���������⣩
    // ��Ҫ��0��
    // DO NOT PUT "ZERO" HERE��
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
            // �����ٷֱ�
            powerPercentage = Mathf.Max(powerGet / powerConsumption, 1f);
            // ��ʵ��Χ����
            rangeReal = range * (1 + (rangeBoostFactor - 1) * powerPercentage) + rangeBoostConstant * powerPercentage;
            // ��ʵ���ټ���
            shootSpeedReal = shootSpeed * (1 + (shootSpeedBoostFactor - 1) * powerPercentage) + shootSpeedBoostConstant * powerPercentage;
            // ��ʵת�ټ���
            rotateSpeedReal = rotateSpeed * (1 + (rotateSpeedBoostFactor - 1) * powerPercentage) + rotateSpeedBoostConstant * powerPercentage;
        }
        else
        {
            rangeReal = range;
            shootSpeedReal = shootSpeed;
            rotateSpeedReal = rotateSpeed;
        }
        rangePanel.transform.localScale = new Vector3(2f * rangeReal, 2f * rangeReal, 1f);
        // �
        shootTimer += Time.deltaTime;
        shootInterval = 1 / shootSpeedReal;
        // �ҵ����е��ˣ�������enemies��
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // ��ÿ�����˼���
        enemyToBase = new Vector3[enemies.Length];
        enemyToTower = new Vector3[enemies.Length];
        enemyWithinRange = new bool[enemies.Length];
        distanceEnemyBase = new float[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            // ���˵���������
            enemyToBase[i] = homeOrBase.transform.position - enemies[i].transform.position;
            // ���˵�������
            enemyToTower[i] = transform.position - enemies[i].transform.position;
            // �������Ƿ������ڲ�
            if (enemyToTower[i].magnitude <= rangeReal)
            {
                enemyWithinRange[i] = true;
                // ��¼��������ؾ���
                distanceEnemyBase[i] = enemyToBase[i].magnitude;
            }
            else
            {
                enemyWithinRange[i] = false;
                // ��¼��������ؾ���Ϊ����ֵ����Ч��
                distanceEnemyBase[i] = Mathf.Infinity;
            }
        }
        // ��ֹĬ��������0�ŵ���
        bool foundEnemy = false;
        minValidEnemyBaseDistanceIndex = 0;
        // ÿ�������ԡ�����̨���ж���ӽ�����
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
        // ��������
        if (foundEnemy)
        {
            // �����ת���������ת
            // ��ʱ��
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
                // ��ʱ��
                if (Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f > 0)
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeedReal), Space.Self);
                }
                // ˳ʱ��
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