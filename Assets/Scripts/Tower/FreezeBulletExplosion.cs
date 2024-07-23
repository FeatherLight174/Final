using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FreezeBulletExplosion : MonoBehaviour
{
    // ��λ�������У��
    // public bool hasHit = false;

    // ��ը�������ܻ����˾����¼������ҪԶ�뱬�Ľ����˺����ã�
    // private float distance;

    // �Ƿ�ҹ
    private bool isNight;

    // ���ڳ�������ң��ӵ����ࣨ����������ͬ��
    public int bulletIndex;
    // ���ڳ�������ң��ӵ��ȼ���ע��д������һ������Ϊ0��
    public int bulletLevel;

    // �ӵ���ը��Χ���ֶ�д�룩
    public float range;
    // public float maxRangeDamageDecrease;

    // ��������ʱ��
    public float duration;

    public Transform rangeScale;
    public SpriteRenderer rangeSprite;

    // �ӵ��˺����ɳ����������
    private float damage;
    private float damageNightFactor;

    // �ӵ����ˣ�δ���ã�
    // public float knockback;

    // �ӵ���͸����
    public int pierceCount = 1;

    private GameObject m_enemy;

    private float m_Timer;

    private Light2D lightRange;

    void Start()
    {
        if (Clock.NowHour >= 6 && Clock.NowHour < 18)
        {
            isNight = false;
        }
        else
        {
            isNight = true;
        }
        damage = GameConstant.towerDamage[bulletIndex, bulletLevel];
        damageNightFactor = GameConstant.towerDamageNightFactor[bulletIndex];
        if (isNight)
        {
            damage = damage * damageNightFactor;
        }
        rangeScale.localScale = new Vector3(2 * range, 2 * range, 1f);
        lightRange = GetComponent<Light2D>();
    }

    void Update()
    {
        m_Timer += Time.deltaTime;
        rangeSprite.color = new Color(0f, 1f, 1f, 0.5f * (duration - m_Timer) / duration);
        GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 1f * (duration - m_Timer) / duration);
        lightRange.intensity = (duration - m_Timer) / duration;
        lightRange.pointLightOuterRadius = range;
        if (m_Timer > duration)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && m_Timer <= 0.1f)
        {
            m_enemy = other.gameObject;
            m_enemy.GetComponent<HPManagement>().TakeDamage(damage);
            pierceCount--;
            //Debug.Log("Hit.");
        }
    }
}
