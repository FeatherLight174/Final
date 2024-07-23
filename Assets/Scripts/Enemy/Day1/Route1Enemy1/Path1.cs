using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path1 : MonoBehaviour
{

    //public NavMeshAgent Nav;
    private HPManagement m_hp;
    private float m_nowHp;
    private float m_v = GameConstant.vFactor;
    private float m_attack = GameConstant.EnemyAttack;
    private float m_attackPre = GameConstant.EnemyAttack2Pre;
    private float m_attackAfter = GameConstant.EnemyAttack2After;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public Vector3 Position1 = new Vector3(-3, 3, 0);
    public float PathY1 = 1;
    public Vector3 Position2 = new Vector3(-3, 1, 0);
    public Vector3 Position3 = new Vector3(-8, 2, 0);
    private float Speed = GameConstant.EnemyMovespeed;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_hp = GetComponent<HPManagement>();
        //Nav = GetComponent<NavMeshAgent>();
        //Nav.SetDestination(WayPoints[0].position);
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
            if (gameObject.transform.position.x >= Position1.x)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                Debug.Log("move");
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= Position2.y)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= Position3.x)
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
            m_Tower.GetComponent<HPManagement>().TakeDamage(m_attack);
            yield return new WaitForSeconds(m_attackAfter);
        }
    }

    public float GetHP()
    {
        return m_nowHp;
    }
    private void OnMouseDown() {

        return;
    }
}
