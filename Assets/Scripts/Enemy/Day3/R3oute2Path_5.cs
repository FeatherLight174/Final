using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R3oute2Path_5 : MonoBehaviour
{

    private float Speed = GameConstant.EnemyMovespeed5;

    private float PosX1 = 3f;
    public float PosX2 = -4;
    public float PosX3 = -9;



    public float PosY1 = -8;
    public float PosY2 = -10;
    public float PosY3 = 1;

    private HPManagement m_HpManager;
    private Animator animator;
    private float m_nowHp;
    private GameObject m_Tower;

    public float showTime = 3f;
    private float m_DieTimer = 0;
    private float m_v = GameConstant.vFactor5;
    private float m_attack = GameConstant.EnemyAttack5;
    private float m_attackPre = GameConstant.EnemyAttack5Pre;
    private float m_attackAfter = GameConstant.EnemyAttack5After;
    private bool m_isAttack = false;
    public bool IsAttacked = false;
    bool m_isup = false;
    bool m_isup2 = false;
    private bool m_IsFreeze = false;
    private float m_FreezeTime = 3;
    private float m_freetimer = 0;
    private bool m_isTouched = false;

    void Start()
    {
        m_HpManager = GetComponent<HPManagement>();
        animator = GetComponent<Animator>();
        m_nowHp = m_HpManager.HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsFreeze)
        {
            Speed *= 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(66 / 255, 197 / 255, 1, 1);
            m_freetimer += Time.deltaTime;
            if (m_freetimer >= m_FreezeTime)
            {
                Speed /= 0.5f;
                m_IsFreeze = false;
                m_freetimer = 0;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
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

            if (gameObject.transform.position.y <= PosY1 && !m_isup)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                gameObject.transform.position -= Vector3.down * Speed * Time.deltaTime;

            }
            else if (gameObject.transform.position.x >= PosX1)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                if (gameObject.transform.position.y < PosY1)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, PosY1 + 0.01f, gameObject.transform.position.z);
                }
                m_isup = true;
            }
            else if (gameObject.transform.position.y >= PosY2 && !m_isup2)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                if (gameObject.transform.position.x > PosX1)
                {
                    gameObject.transform.position = new Vector3(PosX1 - 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
            else if (gameObject.transform.position.x >= PosX2)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                m_isup2 = true;
                if (gameObject.transform.position.y > PosY2)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, PosY2 - 0.01f, gameObject.transform.position.z);
                }
            }
            else if (gameObject.transform.position.y <= PosY3)
            {
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                if (gameObject.transform.position.x > PosX2)
                {
                    gameObject.transform.position = new Vector3(PosX2 - 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
            else if (gameObject.transform.position.x >= PosX3)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                if (gameObject.transform.position.y < PosY3)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, PosY3 + 0.01f, gameObject.transform.position.z);
                }
            }

        }
        else if (m_Tower == null)
        {
            m_isAttack = false;
            animator.SetBool("Attack", false);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Freeze"))
        {
            m_freetimer = 0;
            m_IsFreeze = true;
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
