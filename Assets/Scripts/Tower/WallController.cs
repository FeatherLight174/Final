using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // UI���
    public GameObject sellPanel;
    public GameObject upgradePanel;
    // ����Ǯ����
    private float sellRate = GameConstant.SellFactor;

    // Ѫ������
    public HPManagement scriptHPManagement;

    // ʵ�ʻ�ȡ����
    public float powerGet;
    // ��������������
    private float powerConsumption;
    // [0, 1] �����֣������Ƿ�����
    private float powerPercentage;

    // ����
    public GameObject basePart;

    // ��Ϸ��ʱ��
    public float dayTime;
    // �Ƿ�ҹ��
    private bool isNight;

    // ǽ��Ѫ��
    private float wallRecovery;

    // ǽ���
    public int wallIndex;
    // ǽ�ȼ�
    public int wallLevel = 1;


    // ����Ѫ��������HPManager��
    // public float health;

    // ���ڸ����ϻ��ѵ�Ǯ������ʱ���㣩
    private float currentCost;

    void Start()
    {

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
        }
        else
        {
            isNight = true;
        }
        wallRecovery = GameConstant.wallRecovery[wallLevel - 1];
        powerConsumption = GameConstant.wallPowerConsumption[wallLevel - 1];
        if (powerConsumption > 0)
        {
            powerPercentage = powerGet / powerConsumption;
        }
        scriptHPManagement.HP += powerPercentage * Time.deltaTime * wallRecovery;
    }

    public void Sell()
    {
        sellPanel.SetActive(false);
        upgradePanel.SetActive(false);
        currentCost = 0;
        for (int i = 0; i < wallLevel; i++)
        {
            currentCost += GameConstant.towerUpgradeCost[wallIndex, i];
        }
        GoldAndElectricity.gold += (int)(scriptHPManagement.HP / scriptHPManagement.MaxHP * currentCost * sellRate);
        Destroy(basePart);
    }
    public void Upgrade()
    {
        sellPanel.SetActive(false);
        upgradePanel.SetActive(false);
        if (GoldAndElectricity.gold >= GameConstant.wallUpgradeCost[wallLevel])
        {
            GoldAndElectricity.gold -= (int)(GameConstant.wallUpgradeCost[wallLevel]);
            scriptHPManagement.SetHP(GameConstant.wallUpgradeCost[wallLevel]);
            wallLevel++;
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
    }
}