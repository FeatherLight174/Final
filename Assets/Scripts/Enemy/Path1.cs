using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path1 : MonoBehaviour
{
    public float m_Hp = GameConstant.HPEnemy; 
    private float m_v = GameConstant.vFactor;
    private float m_attack = GameConstant.EnemyAttack;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public float PathX1 = 11;
    public float PathY1 = 1;
    public float PathX2 = 5;
    public float Speed = GameConstant.EnemyMovespeed;
    public bool IsAttacked = false;

    public float showTime = 3f;
    private float m_Timer = 0;
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
        if (!m_isAttack)
        {
            if (PathX1 >= 0)
            {
                gameObject.transform.position += Vector3.left * Speed*Time.deltaTime;
                PathX1 -= Time.deltaTime * Speed;
            }
            else if (PathY1 >= 0)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                PathY1 -= Time.deltaTime* Speed;
            }
            else if(PathX2 >= 0)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                PathX2 -= Time.deltaTime * Speed;
            }
        }
        else if(m_Tower == null)
        {
             m_isAttack=false;
        }
        if (IsAttacked)
        {
            m_Timer += Time.deltaTime;
            if(m_Timer >= showTime)
            {
                IsAttacked = false;
                m_Timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            m_Hp -= GameConstant.BulletAttack;
            IsAttacked = true;
            m_Timer = 0;
        }
        if (collision.gameObject.CompareTag("Building"))
        {
            m_Tower = collision.gameObject;
            m_isAttack=true;
        }
    }

    public float GetHP() {  return m_Hp; }
}
