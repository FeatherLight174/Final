using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float time = 0;
    private float Speed = GameConstant.EnemyMovespeed6;

    public float PosX1 = -18;
    public float PosX2 = -22f;
    public float PosX3 = -20;
    public float PosX4 = -25;
    public float PosX5 = -14;
    public float PosX6 = -9;
    public float PosX7 = -2.5f;
    public float PosX8 = 13;
    public float PosX9 = 14f;
    public float PosX10 = 12f;
    public float PosX11 = 3f;
    public float PosX12 = 0.5f;
    public float PosX13 = -8.5f;

    public float PosY1 = -1;
    public float PosY2 = -5f;
    public float PosY3 = -1;
    public float PosY4 = 3;
    public float PosY5 = -7f;
    public float PosY6 = -4f;
    public float PosY7 = -6f;
    public float PosY8 = 2.5f;
    public float PosY9 = 1f;
    public float PosY10 = -4;
    public float PosY11 = -5f;
    public float PosY12 = -5;
    public float PosY13 = -1f;
    public float PosY14 = 0;

    private HPManagement m_HpManager;
    private Animator animator;
    private float m_nowHp;
    private GameObject m_Tower;

    public float showTime = 3f;
    private float m_DieTimer = 0;
    private float m_v = GameConstant.vFactor6;
    private float m_attack = GameConstant.EnemyAttack6;
    private float m_attackPre = GameConstant.EnemyAttack6Pre;
    private float m_attackAfter = GameConstant.EnemyAttack6After;
    private bool m_isAttack = false;
    public bool IsAttacked = false;
    public int timeStep = 0;

    private bool m_ismove = false;
    public float Idle1Time = 5;
    private bool m_isIdle1 = false;
    private bool m_isIdle2 = false;
    private float Idle2Time = 5;
    private float Idle3Time = 5;
    private bool m_isIdle3 = false;
    private float Idle4Time = 5;
    private bool m_isIdle4 = false;
    private float Idle5Time = 5;
    private bool m_isIdle5 = false;
    private float m_timer = 0;

    void Start()
    {
        m_HpManager = GetComponent<HPManagement>();
        animator = GetComponent<Animator>();
        m_nowHp = m_HpManager.HP;
    }
    void Update()
    {
        //time += Time.deltaTime;
        //Debug.Log(time);
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
        if (!GetComponent<BossTimeChange>().m_isInSkilled)
        {
            if (!m_isAttack)
            {
                if (m_timer < Idle1Time && !m_isIdle1)
                {
                    m_timer += Time.deltaTime;
                }

                else if (gameObject.transform.position.y <= PosY1 && (timeStep == 0 || timeStep == 1))
                {
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                    animator.SetBool("Move", true);
                    m_isIdle1 = true;
                    m_timer = 0;
                    if (timeStep == 0)
                    {
                        timeStep = 1;
                    }
                    gameObject.transform.position -= Vector3.down * Speed * Time.deltaTime;

                }
                else if (gameObject.transform.position.x <= PosX1 && (timeStep == 1 || timeStep == 2))
                {
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", true);
                    gameObject.transform.position -= Vector3.left * Speed * Time.deltaTime;
                    Debug.Log("Right");
                    if (timeStep == 1)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y >= PosY2 && (timeStep == 2 || timeStep == 3))
                {
                    //Debug.Log(333333333333);
                    gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                    if (timeStep == 2)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x >= PosX2 && (timeStep == 3 || timeStep == 4))
                {
                    Debug.Log("LEFT");
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                    gameObject.transform.position -= Vector3.right * Speed * Time.deltaTime;
                    if (timeStep == 3)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y <= PosY3 && (timeStep == 4 || timeStep == 5))
                {
                    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                    if (timeStep == 4)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x <= PosX3 && (timeStep == 5 || timeStep == 6))
                {
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", true);
                    gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                    if (timeStep == 5)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y <= PosY4 && (timeStep == 6 || timeStep == 7))
                {
                    if (!m_isIdle2)
                    {
                        Debug.Log("SSSSSSSSSS");
                        m_timer += Time.deltaTime;
                        animator.SetBool("Move", false);
                        if (m_timer >= Idle2Time)
                        {
                            m_isIdle2 = true;
                            m_timer = 0;
                        }
                    }
                    else
                    {
                        animator.SetBool("Move", true);
                        gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                        if (timeStep == 6)
                        {
                            timeStep += 1;
                        }
                    }
                }
                else if (gameObject.transform.position.x >= PosX4 && (timeStep == 7 || timeStep == 8))
                {
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                    if (timeStep == 7)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y >= PosY5 && (timeStep == 8 || timeStep == 9))
                {
                    gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
                    if (timeStep == 8)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x <= PosX5 && (timeStep == 9 || timeStep == 10))
                {
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", true);
                    gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                    if (timeStep == 9)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y <= PosY6 && (timeStep == 10 || timeStep == 11))
                {
                    if (!m_isIdle3)
                    {
                        animator.SetBool("Move", false);
                        m_timer += Time.deltaTime;
                        if (m_timer >= Idle3Time)
                        {
                            
                            m_timer = 0;
                            m_isIdle3 = true;
                        }
                    }
                    else
                    {
                        animator.SetBool("Move", true);
                        gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                        if (timeStep == 10)
                        {
                            timeStep += 1;
                        }
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
                else if (gameObject.transform.position.y >= PosY7 && (timeStep == 12 || timeStep == 13))
                {
                    gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                    if (timeStep == 12)
                    {
                        timeStep += 1;
                    }

                }
                else if (gameObject.transform.position.x <= PosX7 && (timeStep == 13 || timeStep == 14))
                {
                    if (!m_isIdle4)
                    {
                        animator.SetBool("Move", false);
                        m_timer += Time.deltaTime;
                        if (m_timer >= Idle4Time)
                        {
                            
                            m_timer = 0;
                            m_isIdle4 = true;
                        }
                    }
                    else
                    {
                        animator.SetBool("Move", true);
                        gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                        if (timeStep == 13)
                        {
                            timeStep += 1;
                        }

                    }
                }
                else if (gameObject.transform.position.y <= PosY8 && (timeStep == 14 || timeStep == 15))
                {
                    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                    if (timeStep == 14)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x <= PosX8 && (timeStep == 15 || timeStep == 16))
                {
                    gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                    if (timeStep == 15)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y >= PosY9 && (timeStep == 16 || timeStep == 17))
                {
                    gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
                    if (timeStep == 16)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x <= PosX9 && (timeStep == 17 || timeStep == 18))
                {
                    if (!m_isIdle5)
                    {
                        animator.SetBool("Move", false);
                        m_timer += Time.deltaTime;
                        if (m_timer >= Idle5Time)
                        {
                            
                            m_timer = 0;
                            m_isIdle5 = true;
                        }
                    }
                    else
                    {
                        animator.SetBool("Move", true);
                        gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
                        if (timeStep == 17)
                        {
                            timeStep += 1;
                        }
                    }
                }
                else if (gameObject.transform.position.y >= PosY10 && (timeStep == 18 || timeStep == 19))
                {
                    gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
                    if (timeStep == 18)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x >= PosX10 && (timeStep == 19 || timeStep == 20))
                {
                    animator.SetBool("Right", false);
                    animator.SetBool("Left", true);
                    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                    if (timeStep == 19)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y >= PosY11 && (timeStep == 20 || timeStep == 21))
                {
                    gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
                    if (timeStep == 20)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x >= PosX11 && (timeStep == 21 || timeStep == 22))
                {
                    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                    if (timeStep == 21)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y <= PosY12 && (timeStep == 22 || timeStep == 23))
                {
                    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                    if (timeStep == 22)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x >= PosX12 && (timeStep == 23 || timeStep == 24))
                {
                    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                    if (timeStep == 23)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y <= PosY13 && (timeStep == 24 || timeStep == 25))
                {
                    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                    if (timeStep == 24)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.x >= PosX13 && (timeStep == 25 || timeStep == 26))
                {
                    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                    if (timeStep == 25)
                    {
                        timeStep += 1;
                    }
                }
                else if (gameObject.transform.position.y <= PosY14)
                {
                    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;

                }

            }
            else if (m_Tower == null)
            {
                m_isAttack = false;
                animator.SetBool("Attack", false);
                StopCoroutine(AttackBuilding());
            }

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
