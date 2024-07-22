using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBeingAttacked : MonoBehaviour
{
    public float IsAttacked = 0;
    public float showTime;
    private float prevHP;
    private float nowHP;
    private HPManagement scriptHP;
    void Start()
    {
        scriptHP = GetComponent<HPManagement>();
        prevHP = scriptHP.HP;
    }

    // Update is called once per frame
    void Update()
    {
        nowHP = scriptHP.HP;
        IsAttacked -= Time.deltaTime;
        if (prevHP > nowHP)
        {
            IsAttacked = showTime;
            prevHP = nowHP;
        }
    }
}
