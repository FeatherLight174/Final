using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Path8 : MonoBehaviour
{
    private float m_v = GameConstant.vFactor2;
    private float m_attack = GameConstant.EnemyAttack2;
    private float m_attackCD = GameConstant.AttackCD2;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public float PathX1 = -4;
    public float PathY1 = 1;
    public float PathX2 = -8;
    public float Speed = GameConstant.EnemyMovespeed2;

    private Animator animator;
    private float m_Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HPManagement>().HP <= 0)
        {
            animator.SetBool("Die", true);

        }
        if (!m_isAttack)
        {
            if (gameObject.transform.position.x >= PathX1)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= PathY1)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= PathX2)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;

            }
        }
        else if (m_Tower == null)
        {
            m_isAttack = false;
            animator.SetBool("Attack", false);
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
            // 调用建筑的减少血量方法
            Debug.Log(111111);
            m_Tower.GetComponent<HPManagement>().TakeDamage(m_attack);
            yield return new WaitForSeconds(m_attackCD);
        }
    }

    private void OnMouseDown()
    {
        return;
    }
}
