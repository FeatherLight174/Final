using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos1 : MonoBehaviour
{
    public GameObject[] enemy;
    public float Timer = 3;
    public float factor = 0.5f;
    private int[] min = new int[6] { 1,3,3,4,6,10};
    private int[] max = new int[6];
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
