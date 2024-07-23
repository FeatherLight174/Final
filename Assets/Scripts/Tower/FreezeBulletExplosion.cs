using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FreezeBulletExplosion : MonoBehaviour
{
    // 多次击中问题校正
    // public bool hasHit = false;

    // 爆炸中心与受击敌人距离记录（若需要远离爆心降低伤害可用）
    // private float distance;

    // 是否夜
    private bool isNight;

    // （在常数表查找）子弹种类（与塔索引相同）
    public int bulletIndex;
    // （在常数表查找）子弹等级（注意写索引，一级索引为0）
    public int bulletLevel;

    // 子弹爆炸范围（手动写入）
    public float range;
    // public float maxRangeDamageDecrease;

    // 动画持续时间
    public float duration;

    public Transform rangeScale;
    public SpriteRenderer rangeSprite;

    // 子弹伤害（由常数表决定）
    private float damage;
    private float damageNightFactor;

    // 子弹击退（未启用）
    // public float knockback;

    // 子弹穿透数量
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
