using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path2 : MonoBehaviour
{
    public float m_Hp = GameConstant.HPEnemy;
    private float m_v = GameConstant.vFactor;
    private float m_attack = GameConstant.EnemyAttack;
    private float m_attackCD = GameConstant.AttackCD;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public float PathX1 = 15;
    public float PathY1 = 1;
    public float PathX2 = 1;
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
        if (m_Hp <= 0)
        {
            m_Hp = 0;
            Destroy(gameObject);
        }
        if (!m_isAttack)
        {
            if (PathX1 >= 0)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                PathX1 -= Time.deltaTime * Speed;
            }
            else if (PathY1 >= 0)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                PathY1 -= Time.deltaTime * Speed;
            }
            else if (PathX2 >= 0)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                PathX2 -= Time.deltaTime * Speed;
            }
        }
        else if (m_Tower == null)
        {
            m_isAttack = false;
        }
        if (IsAttacked)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= showTime)
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
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();
            if (bullet.hasHit)
            {
                return;
            }
            m_Hp -= GameConstant.BulletAttack;
            IsAttacked = true;
            m_Timer = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(222222);
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Base"))
        {

            m_Tower = collision.gameObject;
            m_isAttack = true;
            StartCoroutine(AttackBuilding());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Base"))
        {
            m_isAttack = false;
            m_Tower = null;
            StopCoroutine(AttackBuilding());
        }
    }

    IEnumerator AttackBuilding()
    {
        while (m_isAttack && m_Tower != null)
        {
            // 调用建筑的减少血量方法
            Debug.Log(111111);
            m_Tower.GetComponent<HPManagement>().TakeDamage(m_attack);
            yield return new WaitForSeconds(m_attackCD);
        }
    }

    public float GetHP() { return m_Hp; }

    private void OnMouseDown()
    {
        return;
    }
}
