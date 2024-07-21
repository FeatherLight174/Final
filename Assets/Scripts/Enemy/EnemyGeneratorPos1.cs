using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos1 : MonoBehaviour
{ 

    public GameObject[] enemy;
    public float TimerMorning = 1;
    public float TimerAfternoon = 1;
    public float TimerNight = 1;
    public float TimerDawn = 1;
    public float factor = 0.5f;
    private int[] min = new int[6] { 1,3,3,5,6,7};
    private float m_timer = 0;
    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;

        if (Clock.NowHour > 6 && Clock.NowHour <=12)
        {
            if(m_timer >= TimerMorning - Clock.Day *factor)
            {
                Instantiate(enemy[0],gameObject.transform.position,Quaternion.identity);
                m_timer = 0;
            }
        }
        else if (Clock.NowHour > 12 && Clock.NowHour <= 18)
        {
            if (m_timer >= TimerAfternoon - Clock.Day * factor)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
            }
        }

        else if (Clock.NowHour > 18 || Clock.NowHour <= 2)
        {
            if (m_timer >= TimerNight - Clock.Day * factor)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
            }
        }

        else if (Clock.NowHour >= 3 && Clock.NowHour <= 6)
        {
            if (m_timer >= TimerDawn - Clock.Day * factor)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
            }
        }

        


    }


}

    


