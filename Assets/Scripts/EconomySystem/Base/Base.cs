using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    //
    public GameObject upgradePanel;


    //HP
    private float[] fullHP = GameConstant.HomeHP;
    private float currentHP;

    // Current level
    private int level;

    // Level function
    private float[] goldMineCD = GameConstant.HomeGoldProduceCD;
    private float[] goldPerTime = GameConstant.HomeGoldProduce;
    private float m_TimerGold;

    private float[] GeneratingCD = GameConstant.HomePowerProduceCD;
    private float[] ElectricityPerTime = GameConstant.HomePowerProduce;
    private float m_TimerElectricity;

    // Upgrade
    private float upgrade_2 = GameConstant.Homelevel2;
    private float upgrade_3 = GameConstant.Homelevel3;

    // Panel flag
    private int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_TimerGold = 0;
        m_TimerElectricity = 0;
        level = 1;
        currentHP = fullHP[level - 1];
    }

    // Update is called once per frame
    void Update()
    {
        m_TimerGold += Time.deltaTime;
        if (m_TimerGold >= goldMineCD[level - 1])
        {
            GoldAndElectricity.gold += goldPerTime[level - 1];
            m_TimerGold = 0;
        }
        m_TimerElectricity += Time.deltaTime;
        if (m_TimerElectricity >= GeneratingCD[level - 1])
        {
            GoldAndElectricity.electricity += ElectricityPerTime[level - 1];
            m_TimerElectricity = 0;
        }
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (flag % 2 == 0)
        {
            upgradePanel.SetActive(true);
            //feature.SetActive(true);
        }
        else if (flag % 2 == 1)
        {
            upgradePanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag++;
    }

    public void Upgrade()
    {
        if ((level == 1) && (GoldAndElectricity.gold >= upgrade_2))
        {
            level = 2;
            m_TimerGold = 0;
            m_TimerElectricity = 0;
            GoldAndElectricity.gold -= upgrade_2;
            currentHP = fullHP[level - 1];
        }
        if ((level == 2) && (GoldAndElectricity.gold >= upgrade_3)){
            level = 3;
            m_TimerGold = 0;
            m_TimerElectricity = 0;
            GoldAndElectricity.gold -= upgrade_3;
            currentHP = fullHP[level - 1];
        }
       
    }
}

