using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    private HPManagement m_HP;
    private float m_nowHP;
    // Start is called before the first frame update
    void Start()
    {
        m_HP = GetComponent<HPManagement>();
        m_nowHP = m_HP.HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
