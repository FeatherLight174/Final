using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path9 : MonoBehaviour
{

    //public NavMeshAgent Nav;
    private float m_v = GameConstant.vFactor3;
    private float m_attack = GameConstant.EnemyAttack3;
    private float m_attackPre = GameConstant.EnemyAttack3Pre;
    private float m_attackAfter = GameConstant.EnemyAttack3After;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public Vector3 Position1 = new Vector3(-3, 3, 0);
    public float PathY1 = 1;
    public Vector3 Position2 = new Vector3(-3, 1, 0);
    public Vector3 Position3 = new Vector3(-8, 2, 0);
    private float Speed = GameConstant.EnemyMovespeed3;
    private Animator animator;
    private bool isDead = false;
    private bool m_IsFreeze = false;
    private float m_FreezeTime = 3;
    private float m_freetimer = 0;
    private bool m_isTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Nav = GetComponent<NavMeshAgent>();
        //Nav.SetDestination(WayPoints[0].position);
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
        if (gameObject.GetComponent<HPManagement>().HP <= 0)
        {
            animator.SetBool("Die", true);

        }
        if (!m_isAttack && !isDead)
        {
            if (gameObject.transform.position.x >= Position1.x)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= Position2.y)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
                if (gameObject.transform.position.x > Position1.x)
                {
                    gameObject.transform.position = new Vector3(Position1.x - 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
            else if (gameObject.transform.position.x >= Position3.x)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                if (gameObject.transform.position.y > Position2.y)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.y, Position2.y - 0.01f, gameObject.transform.position.z);
                }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
            m_Tower = null;
            animator.SetBool("Attack", false);
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
