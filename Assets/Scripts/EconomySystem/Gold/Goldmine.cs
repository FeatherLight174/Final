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

    private HPManagement Hp;
    // Start is called before the first frame update
    void Start()
    {
        currentCost = goldMineCost;
        level = 1;
        m_Timer = 0;
        Hp = gameObject.GetComponent<HPManagement>();
        Hp.SetHP(GameConstant.HPGold[level - 1]);

    }

    // Update is called once per frame
    void Update()
    {
        if((Clock.NowHour >= 8)&&(Clock.NowHour <= 18))
        {
            m_Timer += Time.deltaTime;
        }
        if (m_Timer >= goldMineCD[level - 1])
        {

            GoldAndElectricity.gold += goldPerTime[level - 1];
            m_Timer = 0;
        }
        if ((!upgradePanel.activeSelf)|| (!sellPanel.activeSelf))
        {
            flag = 0;
        }

    }

    private void OnMouseDown()
    {

        if(flag % 2 == 0)
        {

            if ((level < 3) && (level < Base.level))
            {
                //Debug.Log(true);
                upgradePanel.SetActive(true);
            }


            sellPanel.SetActive(true);
            //feature.SetActive(true);
        }
        if (flag % 2 == 1)
        {

            upgradePanel.SetActive(false);
            
            sellPanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag ++;

    }

    public void Panel()
    {
        if (flag % 2 == 0)
        {

            if ((level < 3)&&( level < Base.level))
            {
                upgradePanel.SetActive(true);
            }


            sellPanel.SetActive(true);
            //feature.SetActive(true);
        }
        if (flag % 2 == 1)
        {

            upgradePanel.SetActive(false);

            sellPanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag++;

    }

    public void Sell()
    {
        GoldAndElectricity.gold += (int)(((Hp.HP / Hp.MaxHP) * currentCost) * sellRate);
        GameConstant.PriceGold -= 10;
        Destroy(gameObject);
    }

    public void Upgrade()
    {
        if ((level == 1) && (GoldAndElectricity.gold >= upgrade_2)){
            level = 2;
            m_Timer = 0;
            GoldAndElectricity.gold -= upgrade_2;
            currentCost += upgrade_2;
            Hp.SetHP(GameConstant.HPGold[level - 1]);
            upgradePanel.SetActive(false);
            sellPanel.SetActive(false);
            flag++;
            return;
        }
        if ((level == 2) && (GoldAndElectricity.gold >= upgrade_3)){
            level = 3;
            m_Timer = 0;
            GoldAndElectricity.gold -= upgrade_3;
            currentCost += upgrade_3;
            Hp.SetHP(GameConstant.HPGold[level - 1]);
            upgradePanel.SetActive(false);
            sellPanel.SetActive(false);
            flag++;
            return;
        }
       
    }
}
