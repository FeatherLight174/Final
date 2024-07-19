using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Cost
    public float generatorCost;
    public float sellRate;

    // Basic function
    public float generatingCD;
    public float electricityPerTime;
    private float m_Timer;

    // HP
    public float fullHP;
    private float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        m_Timer = 0;
        currentHp = fullHP;
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
    }

    void Sell()
    {
        GoldAndElectricity.gold += (int)(((currentHp / fullHP) * generatorCost) * sellRate);
    }
}