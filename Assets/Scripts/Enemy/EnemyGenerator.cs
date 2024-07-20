using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemy;
    public float Timer = 3;

    private float m_timer = 0;
    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        if(m_timer >= Timer)
        {
            int i = Random.Range(0, enemy.Length);
            Instantiate(enemy[i],gameObject.transform.position,Quaternion.identity);
        }
    }
}
