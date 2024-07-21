using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos1 : MonoBehaviour
{
    public GameObject[] enemy;
    public float Timer = 3;
    public float factor = 0.5f;
    private int[] num = new int[6] { 1,2,2,3,3,5};
    private int[]  wave= new int[6] { 3,5,5,8,9,13};
    private float m_timer = 0;
    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        if(Clock.NowHour >= 20)
        {
            
        }
        if (m_timer >= Timer)
        {
            int i = Random.Range(0, enemy.Length);
            Instantiate(enemy[i],gameObject.transform.position,Quaternion.identity);
        }
    }
}
