using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float GeneratingCD;
    public float ElectricityPerTime;
    private float m_Timer;
    // Start is called before the first frame update
    void Start()
    {
        m_Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= GeneratingCD)
        {
            GoldAndElectricity.electricity += ElectricityPerTime;
            m_Timer = 0;
        }
    }
}