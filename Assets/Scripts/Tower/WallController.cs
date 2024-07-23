using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // UI相关
    public GameObject sellPanel;
    public GameObject upgradePanel;
    public GameObject textPanel;
    // 卖出钱比例
    private float sellRate = GameConstant.SellFactor;

    // 血量管理
    public HPManagement scriptHPManagement;

    // 实际获取电量
    public float powerGet;
    // 建筑电力消耗量
    private float powerConsumption;
    // [0, 1] 的数字，代表是否满电
    private float powerPercentage;
    private float powerTimer;

    // 底座
    public GameObject basePart;

    // 游戏内时间
    public float dayTime;
    // 是否夜晚
    private bool isNight;

    // 墙回血量
    private float wallRecovery;

    // 墙编号
    public int wallIndex;
    // 墙等级
    public int wallLevel = 1;


    // 建筑血量（改用HPManager）
    // public float health;

    // 已在该塔上花费的钱（卖出时计算）
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