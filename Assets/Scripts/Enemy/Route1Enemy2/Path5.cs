using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path5 : MonoBehaviour
{

    //public NavMeshAgent Nav;
    public float m_Hp = GameConstant.HPEnemy2; 
    private float m_v = GameConstant.vFactor2;
    private float m_attack = GameConstant.EnemyAttack2;
    private float m_attackCD = GameConstant.AttackCD2;
    private bool m_isAttack = false;
    private GameObject m_Tower;
    public Vector3 Position1 = new Vector3(-3, 3, 0);
    public float PathY1 = 1;
    public Vector3 Position2 = new Vector3(-3,1, 0);
    public Vector3 Position3 = new Vector3(-8,2, 0);
    public float Speed = GameConstant.EnemyMovespeed2;
    public bool IsAttacked = false;
    private Animator animator;
    private bool isDead = false;

    public Transform[] WayPoints;
    public float showTime = 3f;
    private float m_Timer = 0;
    private float m_DieTimer = 0;
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
        if(m_Hp <= 0)
        {
            m_DieTimer += Time.deltaTime;
            m_Hp = 0;
            isDead = true;
            animator.SetBool("Die", true);
            if (m_DieTimer >= 0.5f)
            {
                Destroy(gameObject);
            }
            

            
        }
        if (!m_isAttack&&!isDead)
        {
            if (gameObject.transform.position.x >= Position1.x)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                gameObject.transform.position += Vector3.left * Speed*Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= Position2.y)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if(gameObject.transform.position.x >= Position3.x)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
                
            }
        }
        else if(m_Tower == null)
        {
             m_isAttack=false;
            animator.SetBool("Attack", false);
        }
        if (IsAttacked)
        {
            m_Timer += Time.deltaTime;
            if(m_Timer >= showTime)
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
            m_Tower = null;
            animator.SetBool("Attack", false);
            StopCoroutine(AttackBuilding());
        }
    }

    IEnumerator AttackBuilding()
    {
        while (m_isAttack && m_Tower != null)
        {
            // 调用建筑的减少血量方法
            m_Tower.GetComponent<HPManagement>().TakeDamage(m_attack);
            yield return new WaitForSeconds(m_attackCD);
        }
    }

    public float GetHP() {  return m_Hp; }

    private void OnMouseDown() {
        
        return;
    }
}
