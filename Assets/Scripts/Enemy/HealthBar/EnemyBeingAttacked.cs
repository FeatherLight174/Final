using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeingAttacked : MonoBehaviour
{
    public float IsAttacked = 0;
    public float showTime;
    private HPManagement health;
    private float HP;
    void Start()
    {
        health = GetComponentInParent<HPManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        IsAttacked -= Time.deltaTime;
        if (health.HP != HP)
        {
            HP = health.HP;
            IsAttacked = showTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            IsAttacked = showTime;
        }
    }
}
