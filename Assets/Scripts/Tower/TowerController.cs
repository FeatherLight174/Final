using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TowerController : MonoBehaviour
{
    // UI���
    public GameObject rangePanel;
    public GameObject sellPanel;
    public GameObject upgradePanel;
    private Light2D lightComponent;
    public Light2D lightRange;
    // ����Ǯ����
    private float sellRate = GameConstant.SellFactor;

    // Ѫ������
    public HPManagement scriptHPManagement;

    // ����
    public GameObject basePart;

    // ��Ϸ��ʱ��
    public float dayTime;
    // �Ƿ�ҹ��
    private bool isNight;


    // �����
    public int towerIndex;
    // ���ȼ�
    public int towerLevel = 1;

    // �����Ƿ��õ磨�Զ��жϣ�
    private bool consumesPower;

    // ����Ѫ��������HPManager��
    // public float health;

    // ע�⣺�����ӳ��ȳ˺�ӣ�����ҹ��Χ�������������0����
    // �޵���ʱ������Χ
    private float range;
    // ������Χ�ӳ�������>1����ͬ��
    public float rangeBoostFactor;
    // ������Χ�ӳɳ���
    public float rangeBoostConstant;
    // ҹ��Χ����
    public float rangeNightFactor;
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
    // ʵ�ʹ��ٵĵ��������ڱȽ�ʱ��
    private float shootInterval;

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
    private float powerPercentage;

    // �����ӵ��ٶȣ����ã�
    // public float bulletSpeed;

    // ���������������ã�
    // public float damage;

    // ���˴洢
    public GameObject[] enemies;

    // ���ش洢���Զ�����tagΪ"Base"����Ϸ���壩
    private GameObject homeOrBase;

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

    // ʹ�õ��ӵ��б�
    // �˺������ӵ�������������Ҫѡȡ��ȷ���ӵ�
    /* �ӵ���������
     * 0��ʼ��0��1��2�ֱ��Ӧ1��2��3���޼ӳ��ӵ�
     * 3��4��5��Ӧ1��2��3�������ӳ��ӵ������˵ͷ�Χ��
     */
    public GameObject[] bullets;
    // ���ʵ����׼������Ӧ��׼����С�����ֵ����ʼ�����ӵ�������ѧ���������⣩
    // ��Ҫ��0��
    // DO NOT PUT "ZERO" HERE��
    public float angleDelta;

    // ���ڸ����ϻ��ѵ�Ǯ������ʱ���㣩
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
            // �����ٷֱ�
            powerPercentage = powerGet / powerConsumption;
            if (powerPercentage > 1f)
            {
                powerPercentage = 1;
            }
            // ��ʵ��Χ����
            // rangeReal = range * (1 + (rangeBoostFactor - 1) * powerPercentage) + rangeBoostConstant * powerPercentage;
            rangeReal = range * powerPercentage;
            // ��ʵ���ټ���
            // shootSpeedReal = shootSpeed * (1 + (shootSpeedBoostFactor - 1) * powerPercentage) + shootSpeedBoostConstant * powerPercentage;
            shootSpeedReal = shootSpeed * powerPercentage;
            // ��ʵת�ټ���
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