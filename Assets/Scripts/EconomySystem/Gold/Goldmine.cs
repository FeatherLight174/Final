using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : MonoBehaviour
{
    //
    public GameObject upgradePanel;
    public GameObject sellPanel;

    // Cost
    private float goldMineCost = GameConstant.PriceGold;
    private float currentCost;
    private float sellRate = GameConstant.SellFactor;

    // HP
    private float[] fullHP = GameConstant.HPGold;
    public float currentHP;

    // Current level
    private int level = 1;

    // Level function
    private float[] goldMineCD = GameConstant.GoldCD;
    private float[] goldPerTime = GameConstant.GoldLevelProduce;
    private float m_Timer;

    // Upgrade
    private float upgrade_2 = GameConstant.GoldLevel2;
    private float upgrade_3 = GameConstant.GoldLevel3;

    // Panel flag
    private int flag = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentCost = goldMineCost;
        level = 1;
        m_Timer = 0;
        currentHP = fullHP[level - 1];
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= goldMineCD[level - 1])
        {
            GoldAndElectricity.gold += goldPerTime[level - 1];
            m_Timer = 0;
        }
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if(flag % 2 == 0)
        {
            upgradePanel.SetActive(true);
            sellPanel.SetActive(true);
            //feature.SetActive(true);
        }
        else if (flag % 2 == 1)
        {
            upgradePanel.SetActive(false);
            sellPanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag ++;
    }

    public void Sell()
    {
        GoldAndElectricity.gold += (int)(((currentHP / fullHP[level - 1]) * currentCost) * sellRate);
        Destroy(gameObject);
    }

    public void Upgrade()
    {
        if ((level == 1) && (GoldAndElectricity.gold >= upgrade_2)){
            level = 2;
            m_Timer = 0;
            GoldAndElectricity.gold -= upgrade_2;
            currentCost += upgrade_2;
            currentHP = fullHP[level - 1];
        }
        if ((level == 2) && (GoldAndElectricity.gold >= upgrade_3)){
            level = 3;
            m_Timer = 0;
            GoldAndElectricity.gold -= upgrade_3;
            currentCost += upgrade_3;
            currentHP = fullHP[level - 1];
        }
       
    }
}
