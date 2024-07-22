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
    // Night and Day
    private bool hasUp = false;
    private bool hasDown = false;

    // Day1
    private int day1_interval = 3;
    private int day1_interval2 = 4;

    private int day1_7_count = 1;
    private int day1_8_count = 1;
    private int day1_9_count = 1;
    private int day1_11_count = 3;  
    private int day1_14_count = 4;
    private int day1_16_count = 3;
    private int day1_19_count = 4;
    private int day1_21_count = 4;  
    private int day1_22_count = 4;
    private int day1_22_count2 = 3;
    private int day1_23_count = 3;
   

    // Day2

    private int day2_interval = 4;

    private int day2_0_count = 3;
    private int day2_1_count = 3;
    private int day2_2_count_2 = 1;
    private int day2_2_count = 2;
    private int day2_3_count = 2;
    private int day2_4_count = 2;
    private int day2_5_count = 2;

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        if(Clock.NowHour == 18)
        {
            hasDown = false;
            if(hasUp == false)
            {
                GameConstant.EnemyMovespeed = GameConstant.EnemyMovespeed *= 1.5f;
                Debug.Log(GameConstant.EnemyMovespeed);
                GameConstant.EnemyAttack = GameConstant.EnemyAttack * 1.2f;
                GameConstant.EnemyMovespeed2 = GameConstant.EnemyMovespeed2 * 1.5f;
                GameConstant.EnemyAttack2 = GameConstant.EnemyAttack2 * 1.2f;
                hasUp = true;
            }
            
        }
        else if(Clock.NowHour == 5)
        {
            hasUp = false;
            if (hasDown == false)
            {
                GameConstant.EnemyMovespeed /= 1.5f;
                GameConstant.EnemyAttack /= 1.2f;
                GameConstant.EnemyMovespeed2 /= 1.5f;
                GameConstant.EnemyAttack2 /= 1.2f;
                hasDown = true;
            }
            
        }
        //
        if ((Clock.NowHour == 7) && (Clock.Day == 1))
        {
            if (day1_7_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_7_count--;
            }

        }
        else if ((Clock.NowHour == 8) && (Clock.Day == 1))
        {
            if (day1_8_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_8_count--;
            }

        }
        else if ((Clock.NowHour == 9) && (Clock.Day == 1))
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
        else if ((Clock.NowHour == 21) && (Clock.Day == 1))
        {
            if (day1_21_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_21_count--;
                }
            }
        }
        else if ((Clock.NowHour == 22) && (Clock.Day == 1))
        {
            if (day1_22_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_22_count--;
                }
            }
            if (day1_22_count2 > 0)
            {
                if (m_timer >= day1_interval2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_22_count2--;
                }
            }
        }
        else if ((Clock.NowHour == 23) && (Clock.Day == 1))
        {
            if (day1_23_count > 0)
            {
                if (m_timer >= day1_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_23_count--;
                }
            }
        }
        else if ((Clock.NowHour == 0) && (Clock.Day == 2))
        {
            if (day2_0_count > 0)
            {
                if (m_timer >= day2_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_0_count--;
                }
            }
        }
        else if ((Clock.NowHour == 1) && (Clock.Day == 2))
        {
            if (day2_1_count > 0)
            {
                if (m_timer >= day2_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_1_count--;
                }
            }
        }
        else if ((Clock.NowHour == 2) && (Clock.Day == 2))
        {

            if (day2_2_count > 0)
            {
                if (m_timer >= day2_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_2_count--;
                }
            }
        }
        else if ((Clock.NowHour == 3) && (Clock.Day == 2))
        {
            if (day2_3_count > 0)
            {
                if (m_timer >= day2_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_3_count--;
                }
            }
        }
        else if ((Clock.NowHour == 4) && (Clock.Day == 2))
        {
            if (day2_2_count_2 > 0)
            {
                Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day2_2_count_2--;
            }
            if (day2_4_count > 0)
            {
                if (m_timer >= day2_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_4_count--;
                }
            }
        }
        else if ((Clock.NowHour == 5) && (Clock.Day == 2))
        {
            if (day2_5_count > 0)
            {
                if (m_timer >= day2_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_5_count--;
                }
            }
        }
    }
}
    
    






    


