using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rout1Path1_3 : MonoBehaviour
{
    private float m_v = GameConstant.vFactor5;
    private float m_attack = GameConstant.EnemyAttack5;
    private float m_attackCD = GameConstant.AttackCD5;
    private float m_attackPre = GameConstant.EnemyAttack5Pre;
    private float m_attackAfter = GameConstant.EnemyAttack5After;  
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public float PathX1 = 14;
    public float PathX2 = -8;
    public float PathY1 = 2;

    private float Speed = GameConstant.EnemyMovespeed5;
    private bool m_IsFreeze = false;
    private float m_FreezeTime = 3;
    private float m_freetimer = 0;
    private bool m_isTouched = false;
    

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsFreeze)
        {
            Speed *= 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(66/255,197/255,1,1);
            m_freetimer += Time.deltaTime;
            if(m_freetimer >= m_FreezeTime)
            {
                Speed /= 0.5f;
                m_IsFreeze=false;
                m_freetimer=0;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
        if (gameObject.GetComponent<HPManagement>().HP <= 0)
        {
            animator.SetBool("Die", true);

        }
        if (!m_isAttack)
        {
            if (gameObject.transform.position.x >= PathX1)
            {
                animator.SetBool("Left", true);
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y <= PathY1)
            {
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
                if (gameObject.transform.position.x > PathX1)
                {
                    gameObject.transform.position = new Vector3(PathX1 + 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
            else if (gameObject.transform.position.x >= PathX2)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                if (gameObject.transform.position.y < PathY1)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, PathY1 - 0.01f, gameObject.transform.position.z);
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
        Debug.Log(222222);
        if (collision.gameObject.CompareTag("Building") || collision.gameObject.CompareTag("Base"))
        {

            m_Tower = collision.gameObject;
            m_isAttack = true;
            animator.SetBool("Attack", true);
            StartCoroutine(AttackBuilding());
        }
        if (collision.gameObject.CompareTag("Freeze"))
        {
            m_freetimer = 0;
            m_IsFreeze = true;
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

    private void OnMouseDown()
    {
        return;
    }
}