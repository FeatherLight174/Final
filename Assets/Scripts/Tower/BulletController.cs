using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // ��λ�������У��
    public bool hasHit = false;

    // �Ƿ�ҹ
    private bool isNight;

    public bool isExplosive = false;

    // ���ڳ�������ң��ӵ����ࣨ����������ͬ��
    public int bulletIndex;
    // ���ڳ�������ң��ӵ��ȼ���ע��д������һ������Ϊ0��
    public int bulletLevel;

    // �ӵ������̱���
    public float maxRangeTimes = 1; 
    // �ӵ���̣�������Ϊ������Χ�ġ�����
    // ע������Ҫ��һ����̣�
    private float range;
    private float rangeNightFactor;
    public float rangePowerBoostFactor;
    public float rangePowerBoostConstant;

    // �ӵ�����ʱ�䣨�Զ����㣩
    private float duration;

    // �ӵ��˺����ɳ����������
    private float damage;
    private float damageNightFactor;

    // �ӵ��ٶȣ��ɳ����������
    private float speed;

    // �ӵ����ˣ�δ���ã�
    // public float knockback;

    // �ӵ���͸����
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
        // ���籬���ӵ�������ʱ����һ����ը
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
