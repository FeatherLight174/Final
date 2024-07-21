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
    private float m_timer = 0;

    // Day1
    private int day1_interval = 1;

    private int day1_9_count = 1;
    private int day1_11_count = 2;  
    private int day1_14_count = 2;
    private int day1_16_count = 2;
    private int day1_19_count = 2;
    private int day1_21_count = 1;  
    private int day1_22_count = 1;
    private int day1_23_count = 1;
    private int day1_24_count = 1;

    // Day2

    private int day2_interval = 1;

    private int day2_1_count = 1;
    private int day2_2_count_2 = 1;

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        /*if(Clock.NowHour == 18)
        {
            GameConstant.EnemyMovespeed = GameConstant.EnemyMovespeed + 1f;
            GameConstant.EnemyAttack = GameConstant.EnemyAttack * 1.2f;
            GameConstant.EnemyMovespeed2 = GameConstant.EnemyMovespeed2 * 1.5f;
            GameConstant.EnemyAttack2 = GameConstant.EnemyAttack2 * 1.2f;
        }
        else if(Clock.NowHour == 5)
        {
            GameConstant.EnemyMovespeed /= 1.5f;
            GameConstant.EnemyAttack /= 1.2f;
            GameConstant.EnemyMovespeed2 /= 1.5f;
            GameConstant.EnemyAttack2 /= 1.2f;
        }*/
        //
        if ((Clock.NowHour == 9) && (Clock.Day == 1))
        {
            if (day1_9_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_9_count--;
            }

        }
        else if ((Clock.NowHour == 11) && (Clock.Day == 1))
        {
            if (day1_11_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_11_count--;
                }
            }
        }
        else if ((Clock.NowHour == 14) && (Clock.Day == 1))
        {
            if (day1_14_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_14_count--;
                }
            }
        }
        else if ((Clock.NowHour == 16) && (Clock.Day == 1))
        {
            if (day1_16_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_16_count--;
                }
            }
        }
        else if ((Clock.NowHour == 19) && (Clock.Day == 1))
        {
            GameConstant.EnemyMovespeed = GameConstant.EnemyMovespeed + 1f;
            if (day1_19_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_19_count--;
                }
            }
        }
        if ((Clock.NowHour == 21) && (Clock.Day == 1))
        {
            if (day1_21_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_21_count--;
            }
        }
        if ((Clock.NowHour == 22) && (Clock.Day == 1))
        {
            if (day1_22_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_22_count--;
            }
        }
        if ((Clock.NowHour == 23) && (Clock.Day == 1))
        {
            if (day1_23_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_23_count--;
            }
        }
        if ((Clock.NowHour == 24) && (Clock.Day == 1))
        {
            if (day1_24_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_24_count--;
            }
        }
        if ((Clock.NowHour == 1) && (Clock.Day == 2))
        {
            if (day2_1_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day2_1_count--;
            }
        }
        if ((Clock.NowHour == 2) && (Clock.Day == 2))
        {
            if (day2_2_count_2 > 0)
            {
                Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day2_2_count_2--;
            }
        }
    }
}
    
    






    


