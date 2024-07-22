using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBeingAttacked : MonoBehaviour
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
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            IsAttacked = showTime;
        }
    }
}
