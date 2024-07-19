using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float goldMineCD;
    public float goldPerTime;
    private float m_TimerGold;
    public float GeneratingCD;
    public float ElectricityPerTime;
    private float m_TimerElectricity;
    // Start is called before the first frame update
    void Start()
    {
        m_TimerGold = 0;
        m_TimerElectricity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_TimerGold += Time.deltaTime;
        if (m_TimerGold >= goldMineCD)
        {
            GoldAndElectricity.gold += goldPerTime;
            m_TimerGold = 0;
        }
        m_TimerElectricity += Time.deltaTime;
        if (m_TimerElectricity >= GeneratingCD)
        {
            GoldAndElectricity.electricity += ElectricityPerTime;
            m_TimerElectricity = 0;
        }
    }
}
