using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    private float SunDamage = 30;
    private HPManagement m_HP;
    private float m_nowHP;
    public int SP = 0;
    public int MAXSP = 5;
    public bool IsIntensify = false;
    public float damage = 10;
    private float timer = 1;
    private float m_time = 0;   
    private GameObject[] DamageObject;
    public float CD = 1;


    // Start is called before the first frame update
    void Start()
    {
        m_HP = GetComponentInParent<HPManagement>();
        m_nowHP = m_HP.HP;
    } 

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        if (m_time >= timer)
        {
            m_nowHP = m_HP.HP;
            if (!Clock.IsNight)
            {

                Debug.Log("XXXX");
                m_HP.TakeDamage(SunDamage);
            }
            m_time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Building"))
        {
            StartCoroutine(AttackBuilding(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("BloodBlade"))
        {
            if (m_nowHP <= m_HP.MaxHP * 0.85)
            {

                m_HP.AddHP(m_HP.MaxHP * 0.2f);
                Destroy(collision.gameObject);
            }
        }
        if(collision.gameObject.GetComponent<HPManagement>() != null)
        {
            collision.gameObject.GetComponent<HPManagement>().TakeDamage(damage);
        }
        if (!Clock.IsNight)
        {
            return;
        }
        else if (Clock.IsNight)
        {
            if (collision.gameObject.CompareTag("BloodBlade"))
            {
                SP += 1;
                if(SP == MAXSP)
                {
                    IsIntensify = true;
                }
            }
        }
    }
    IEnumerator AttackBuilding(GameObject collision)
    {
        int x = 5;
        while (collision != null && x != 0 )
        {
            // 调用建筑的减少血量方法
            if (collision.GetComponent<HPManagement>() != null)
            {
                collision.GetComponent<HPManagement>().TakeDamage(damage);
            }
            yield return new WaitForSeconds(CD);
            x--;
        }
    }
}
