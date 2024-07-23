using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // UI���
    public GameObject sellPanel;
    public GameObject upgradePanel;
    public GameObject textPanel;
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
    private float powerTimer;

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
        if (dayTime != Clock.NowHour || powerTimer > 0)
        {
            powerTimer += Time.deltaTime;
        }
        if (powerTimer > 0.5f)
        {
            GetPower();
            powerTimer = 0;
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
        if (scriptHPManagement.HP + powerPercentage * Time.deltaTime * wallRecovery > scriptHPManagement.MaxHP)
        {
            scriptHPManagement.HP = scriptHPManagement.MaxHP;
        }
        else
        {
            scriptHPManagement.HP += powerPercentage * Time.deltaTime * wallRecovery;
        }
    }

    public void Sell()
    {
        sellPanel.SetActive(false);
        upgradePanel.SetActive(false);
        textPanel.SetActive(false);
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
        textPanel.SetActive(false);
        if (GoldAndElectricity.gold >= GameConstant.wallUpgradeCost[wallLevel])
        {
            GoldAndElectricity.gold -= (int)(GameConstant.wallUpgradeCost[wallLevel]);
            scriptHPManagement.SetHP(GameConstant.wallUpgradeCost[wallLevel]);
            wallLevel++;
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
    }
}