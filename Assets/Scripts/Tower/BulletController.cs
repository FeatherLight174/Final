using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 多次击中问题校正
    public bool hasHit = false;

    // 是否夜
    private bool isNight;

    public bool isExplosive = false;

    // （在常数表查找）子弹种类（与塔索引相同）
    public int bulletIndex;
    // （在常数表查找）子弹等级（注意写索引，一级索引为0）
    public int bulletLevel;

    // 子弹最大射程倍数
    public float maxRangeTimes = 1; 
    // 子弹射程（最大距离为炮塔范围的↑倍）
    // 注意这里要填一倍射程！
    private float range;
    private float rangeNightFactor;
    public float rangePowerBoostFactor;
    public float rangePowerBoostConstant;

    // 子弹持续时间（自动计算）
    private float duration;

    // 子弹伤害（由常数表决定）
    private float damage;
    private float damageNightFactor;

    // 子弹速度（由常数表决定）
    private float speed;

    // 子弹击退（未启用）
    // public float knockback;

    // 子弹穿透数量
    public int pierceCount = 1;
    public int pierceNightConstant = 0;

    private GameObject m_enemy;

    public GameObject explosion;

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
        speed = GameConstant.towerBulletSpeed[bulletIndex, bulletLevel];
        range = GameConstant.towerRange[bulletIndex, bulletLevel];
        rangeNightFactor = GameConstant.towerRangeNightFactor[bulletIndex];
        damage = GameConstant.towerDamage[bulletIndex, bulletLevel];
        damageNightFactor = GameConstant.towerDamageNightFactor[bulletIndex];
        if (isNight)
        {
            range = range * rangeNightFactor;
            damage = damage * damageNightFactor;
            pierceCount += pierceNightConstant;
        }

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
        // 例如爆破子弹在销毁时生成一个爆炸
        if (isExplosive)
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.25f), Quaternion.identity);
        }
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            m_enemy = other.gameObject;
            if (isExplosive)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                m_enemy.GetComponent<HPManagement>().TakeDamage(damage);
                pierceCount--;
            }
        }
        
    }
}
