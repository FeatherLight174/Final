using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : MonoBehaviour
{
    // Cost
    public float goldMineCost;

    // Basic function
    public float goldMineCD;
    public float goldPerTime;
    private float m_Timer;

    // HP
    public float fullHP;
    private float currentHp;


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
        if (m_Timer >= goldMineCD)
        {
            GoldAndElectricity.gold += goldPerTime;
            m_Timer = 0;
        }
    }

    void Sell()
    {
        GoldAndElectricity.gold += (int)((currentHp / fullHP) * goldMineCost);
    }
}
