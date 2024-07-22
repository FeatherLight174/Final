using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rout1Path1 : MonoBehaviour
{
    private float m_v = GameConstant.vFactor;
    private float m_attack = GameConstant.EnemyAttack;
    private float m_attackCD = GameConstant.AttackCD;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public float PathX1 = 14;
    public float PathX2 = -8;
    public float PathY1 = 2;

    private float Speed = GameConstant.EnemyMovespeed;

    private Animator animator;
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
                Debug.Log("SSSSSS");
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y <= PathY1)
            {
                gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
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