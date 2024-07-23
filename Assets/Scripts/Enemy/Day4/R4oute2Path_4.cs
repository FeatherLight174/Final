using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R4oute2Path : MonoBehaviour
{

    private float Speed = GameConstant.EnemyMovespeed4;

    public float PosX1 = -25;
    private float PosX2 = -14.5f;
    public float PosX3 = -10;



    public float PosY1 = -8;
    public float PosY2 = -4.5f;
    public float PosY3 = 0;

    private HPManagement m_HpManager;
    private Animator animator;
    private float m_nowHp;
    private GameObject m_Tower;

    public float showTime = 3f;
    private float m_DieTimer = 0;
    private float m_v = GameConstant.vFactor4;
    private float m_attack = GameConstant.EnemyAttack4;
    private float m_attackPre = GameConstant.EnemyAttack4Pre;
    private float m_attackAfter = GameConstant.EnemyAttack4After;
    private bool m_isAttack = false;
    public bool IsAttacked = false;
    bool m_isup = false;
    bool m_isup2 = false;

    void Start()
    {
        PosX2 = Random.Range(-16, -13);
        m_HpManager = GetComponent<HPManagement>();
        animator = GetComponent<Animator>();
        m_nowHp = m_HpManager.HP;
    }

    // Update is called once per frame
    void Update()
    {
        m_nowHp = m_HpManager.HP;
        if (m_nowHp <= 0)
        {

            m_DieTimer += Time.deltaTime;
            m_nowHp = 0;
            animator.SetBool("Die", true);
            if (m_DieTimer >= 0.5f)
            {
                Destroy(gameObject);
            }
        }
        if (!m_isAttack)
        {
            if (gameObject.transform.position.x <= PosX1)
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                gameObject.transform.position -= Vector3.left * Speed * Time.deltaTime;
                m_isup = true;
            }
            else if (gameObject.transform.position.y <= PosY1)
            {
                
                gameObject.transform.position -= Vector3.down * Speed * Time.deltaTime;

            }
            else if (gameObject.transform.position.x <= PosX2)
            {
                gameObject.transform.position -= Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y <= PosY2)
            {
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x <= PosX3)
            {
                gameObject.transform.position -= Vector3.left * Speed * Time.deltaTime;
                gameObject.transform.position -= Vector3.left * Speed * Time.deltaTime;
                m_isup2 = true;
            }
            else if (gameObject.transform.position.y <= PosY3)
            {
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
            }


        }
        else if (m_Tower == null)
        {
            m_isAttack = false;
            animator.SetBool("Attack", false);
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
            IsAttacked = true;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Base"))
        {

            m_Tower = collision.gameObject;
            m_isAttack = true;
            animator.SetBool("Attack", true);
            StartCoroutine(AttackBuilding());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Base"))
        {
            m_isAttack = false;
            animator.SetBool("Attack", false);
            m_Tower = null;
            StopCoroutine(AttackBuilding());
        }
    }

    IEnumerator AttackBuilding()
    {
        while (m_isAttack && m_Tower != null)
        {
            yield return new WaitForSeconds(m_attackPre);
            // 调用建筑的减少血量方法
            if (m_Tower != null)
            {
                m_Tower.GetComponent<HPManagement>().TakeDamage(m_attack);
            }
            yield return new WaitForSeconds(m_attackAfter);
        }
    }

    public float GetHP()
    {
        return m_nowHp;
    }
    private void OnMouseDown()
    {

        return;
    }

}
