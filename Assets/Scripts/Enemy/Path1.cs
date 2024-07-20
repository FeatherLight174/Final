using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path1 : MonoBehaviour
{
    private float m_Hp = GameContanst.HPEnemy; 
    private float m_v = GameContanst.vFactor;
    private float m_attack = GameContanst.EnemyAttack;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Hp <= 0)
        {
            m_Hp = 0;
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            m_Hp -= GameContanst.BulletAttack;
        }
        if (collision.gameObject.CompareTag("Building"))
        {
            
        }
    }
}
