using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : MonoBehaviour
{
    //
    public GameObject panel;

    // Cost
    public float goldMineCost;
    private float currentCost;
    public float sellRate;

    // HP
    public float[] fullHP;
    private float currentHP;

    // Current level
    private int level = 1;

    // Level function
    public float[] goldMineCD;
    public float[] goldPerTime;
    private float m_Timer;

    // Upgrade
    public float upgrade_2;
    public float upgrade_3;


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
    }

    private void OnMouseDown()
    {
        panel.SetActive(true);
    }

    public void Sell()
    {
        GoldAndElectricity.gold += (int)(((currentHP / fullHP[level - 1]) * goldMineCost) * sellRate);
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
