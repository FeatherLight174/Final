using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool hasHit = false; 
    // �ӵ������̱���
    public float maxRangeTimes = 1; 
    // �ӵ���̣�������Ϊ������Χ�ġ�����
    // ע������Ҫ��һ����̣�
    public float range;
    // �ӵ�����ʱ�䣨�Զ����㣩
    private float duration;
    // �ӵ��˺�
    public float damage;
    // �ӵ��ٶ�
    public float speed;
    // �ӵ����ˣ�δ���ã�
    // public float knockback;
    // �ӵ���͸����
    public int pierceCount = 1;

    private GameObject m_enemy;
    void Start()
    {
        duration = maxRangeTimes * range / speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (pierceCount <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += Time.deltaTime * speed * new Vector3(Mathf.Cos(transform.eulerAngles.z / 180f * Mathf.PI), Mathf.Sin(transform.eulerAngles.z / 180f * Mathf.PI), 0f);
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        // ���籬���ӵ�������ʱ����һ����ը
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pierceCount <= 0)
        {
            hasHit = true;
            Destroy(gameObject);
        }
        if (hasHit)
        {
            return;
        }
        //Debug.Log("Hit sth.");
        if (other.gameObject.CompareTag("Enemy"))
        {
            m_enemy = other.gameObject;
            //Debug.Log("DIE");
            //if (m_enemy.GetComponent<HPManagement>().HP <= GameConstant.BulletAttack)
            //{
                //m_enemy.GetComponent<AudioSource>().Play();
                //Debug.Log("DIE");
            //}
            m_enemy.GetComponent<HPManagement>().TakeDamage(GameConstant.BulletAttack);
            pierceCount--;
            //Debug.Log("Hit.");
        }
        
    }
}
