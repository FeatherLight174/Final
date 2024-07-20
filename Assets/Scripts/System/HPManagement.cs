using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManagement : MonoBehaviour
{
    public float HP;
    public float MaxHP;

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        } 
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    public void SetHP(float MAX)
    {
        HP = HP/MaxHP * MAX;
        MaxHP = MAX;
    }
}
