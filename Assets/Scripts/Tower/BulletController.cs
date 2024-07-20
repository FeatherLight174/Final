using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool hasHit = false; 
    // 子弹最大射程倍数
    public float maxRangeTimes = 1; 
    // 子弹射程（最大距离为炮塔范围的↑倍）
    // 注意这里要填一倍射程！
    public float range;
    // 子弹持续时间（自动计算）
    private float duration;
    // 子弹伤害
    public float damage;
    // 子弹速度
    public float speed;
    // 子弹击退（未启用）
    // public float knockback;
    // 子弹穿透数量
    public int pierceCount = 1;
    void Start()
    {
        duration = maxRangeTimes * range / speed;
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("Hit sth.");
        if (other.gameObject.CompareTag("Enemy"))
        {
            pierceCount--;
            Debug.Log("Hit.");
        }
        
    }
}
