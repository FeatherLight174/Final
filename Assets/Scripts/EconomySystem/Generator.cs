using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Cost
    private float generatorCost = GameConstant.PricePower;
    private float sellRate = GameConstant.SellFactor;

    // Basic function
    private float generatingCD = GameConstant.PowerCD;
    private float electricityPerTime = GameConstant.PowerProduce;
    private float m_Timer;

    // HP
    private float fullHP = GameConstant.HPPower;
    public float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        m_Timer = 0;
        currentHP = fullHP;
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= generatingCD)
        {
            GoldAndElectricity.electricity += electricityPerTime;
            m_Timer = 0;
        }
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Sell()
    {
        GoldAndElectricity.gold += (int)(((currentHP / fullHP) * generatorCost) * sellRate);
    }
}