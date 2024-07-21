using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos1 : MonoBehaviour
{
    public static GameConstant Instance { get; private set; }

    public GameObject[] enemy;
    public float factor = 0.5f;
    private int[] min = new int[6] { 1,3,3,5,6,7};
    private int[]  max= new int[6] { 3,5,5,8,9,13};
    private float m_timer = 0;
    // Update is called once per frame
    void Update()
    {
        
       

            
            
    }

    public void Generate()
    {
        if (Clock.NowHour >=20 || Clock.NowHour <= 3)
        {
            int num = Random.Range(min[5], max[5] + 1) * (int)(1 + factor * Clock.Day);
            for (int index = 0; index <= num; index++)
            {
                int i = Random.Range(0, enemy.Length);
                Instantiate(enemy[i], gameObject.transform.position, Quaternion.identity);
            }
        }
        else if (Clock.NowHour >=4 && Clock.NowHour <= 8)
        {
            int num = Random.Range(min[0], max[0] + 1) * (int)(1 + factor * Clock.Day);
            for (int index = 0; index <= num; index++)
            {
                int i = Random.Range(0, enemy.Length);
                Instantiate(enemy[i], gameObject.transform.position, Quaternion.identity);
            }
        }

        else if (Clock.NowHour >= 8 && Clock.NowHour <= 11)
        {
            int num = Random.Range(min[1], max[1] + 1) * (int)(1 + factor * Clock.Day);
            for (int index = 0; index <= num; index++)
            {
                int i = 0;
                Instantiate(enemy[i], gameObject.transform.position, Quaternion.identity);
            }
        }

        else if (Clock.NowHour>= 12 && Clock.NowHour <= 14)
        {
            int num = Random.Range(min[2], max[2] + 1) * (int)(1 + factor * Clock.Day);
            for (int index = 0; index <= num; index++)
            {
                int i = Random.Range(0, enemy.Length);
                Instantiate(enemy[i], gameObject.transform.position, Quaternion.identity);
            }
        }

        else if (Clock.NowHour >= 14 && Clock.NowHour <= 18)
        {
            int num = Random.Range(min[3], max[3] + 1) * (int)(1 + factor * Clock.Day);
            for (int index = 0; index <= num; index++)
            {
                int i = Random.Range(0, enemy.Length);
                Instantiate(enemy[i], gameObject.transform.position, Quaternion.identity);
            }
        }

        else if (Clock.NowHour == 19)
        {
            int num = Random.Range(min[4], max[4] + 1) * (int)(1 + factor * Clock.Day);
            for (int index = 0; index <= num; index++)
            {
                int i = Random.Range(0, enemy.Length) ;
                Instantiate(enemy[i], gameObject.transform.position, Quaternion.identity);
            }
        }

        
    }

}
