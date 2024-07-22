using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeingAttacked : MonoBehaviour
{
    public float IsAttacked = 0;
    public float showTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsAttacked -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            IsAttacked = showTime;
        }
    }
}
