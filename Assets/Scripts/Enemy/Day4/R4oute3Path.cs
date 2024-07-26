using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R4oute3Path : MonoBehaviour
{

    private float Speed = GameConstant.EnemyMovespeed5;

    public float PosX1 = -18;
    public float PosX2 = -22f;
    public float PosX3 = -20;
    public float PosX4 = -25;
    public float PosX5 = -14;
    public float PosX6 = -8;

    public float PosY1 = -1;
    public float PosY2 = -5f;
    public float PosY3 = -1;
    public float PosY4 = 3;
    private float PosY5 = -8f;
    private float PosY6 = -4f;
    public float PosY7 = 1;

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
    public int timeStep = 0;
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

            if (gameObject.transform.position.y <= PosY1 &&(timeStep == 0 || timeStep == 1))
            {
                Debug.Log("Speed"+Speed);
                
                if(timeStep == 0)
                {
                    timeStep = 1;
                    
                }
                gameObject.transform.position -= Vector3.down * Speed * Time.deltaTime;

            }
            else if (gameObject.transform.position.x <= PosX1 &&(timeStep == 1 || timeStep == 2))
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right",true);
                gameObject.transform.position -= Vector3.left * Speed * Time.deltaTime;
                if(timeStep == 1)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.y >= PosY2 && (timeStep == 2 || timeStep == 3))
            {
                //Debug.Log(333333333333);
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                if (timeStep == 2)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.x >= PosX2 && (timeStep == 3 || timeStep == 4))
            {
                
                gameObject.transform.position -= Vector3.right * Speed * Time.deltaTime;
                if (timeStep == 3)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.y <= PosY3 && (timeStep == 4 || timeStep == 5))
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                if(timeStep == 4)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.x <= PosX3 && (timeStep == 5 || timeStep == 6))
            {

                gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                if (timeStep == 5)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.y <= PosY4 && (timeStep == 6 || timeStep == 7))
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                if (timeStep == 6)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.x >= PosX4 && (timeStep == 7 || timeStep == 8))
            {
                
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                if (timeStep == 7)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.y >= PosY5 && (timeStep == 8 || timeStep == 9))
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
                if (timeStep == 8)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.x <= PosX5 && (timeStep == 9 || timeStep == 10))
            {
                
                gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                if (timeStep == 9)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.y <= PosY6 && (timeStep == 10 || timeStep == 11))
            {
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                if (timeStep == 10)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.x <= PosX6 && (timeStep == 11 || timeStep == 12))
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                if (timeStep == 11)
                {
                    timeStep += 1;
                }
            }
            else if (gameObject.transform.position.y <= PosY7 && (timeStep == 11 || timeStep == 12))
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
