using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos4 : MonoBehaviour
{
    public GameObject[] enemy;
    public float TimerMorning = 1;
    public float TimerAfternoon = 1;
    public float TimerNight = 1;
    public float TimerDawn = 1;
    public float factor = 0.5f;
    private float m_timer = 0;
    private float m_timer2 = 0;
    // Night and Day
    private int day2_interval = 1;
    private int day2_interval2 = 2;
    private int day2_interval3 = 3;
    private int day2_interval7 = 7;
    private int day2_interval4 = 4;
    private int day2_interval5 = 5;


    private int day3_8_count_3 = 1;
    private int day3_9_count = 0;
    private int day3_10_count = 0;
    private int day3_11_count = 0;

    private int day3_12_count = 4;
    private int day3_13_count = 1;
    private int day3_14_count = 4;
    private int day3_15_count = 1;
    private int day3_16_count = 4;
    private int day3_17_count = 1;

    private int day3_18_count = 0;
    private int day3_19_count = 0;
    private int day3_20_count = 0;
    private int day3_21_count = 0;
    private int day3_22_count = 0;
    private int day3_23_count = 0;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_timer2 += Time.deltaTime;

        
        
        if ((Clock.NowHour == 8) && (Clock.Day == 3))
        {
            if (day3_8_count_3 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_8_count_3--;
                }
            }

        }
        else if ((Clock.NowHour == 9) && (Clock.Day == 3))
        {
            if (day3_9_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_9_count--;
                }
            }

        }
        else if ((Clock.NowHour == 10) && (Clock.Day == 3))
        {
            if (day3_10_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_10_count--;
                }
            }

        }

        else if ((Clock.NowHour == 11) && (Clock.Day == 3))
        {
            if (day3_11_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_11_count--;
                }
            }

        }
        else if ((Clock.NowHour == 12) && (Clock.Day == 3))
        {
            if (day3_12_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_12_count--;
                }
            }

        }
        else if ((Clock.NowHour == 13) && (Clock.Day == 3))
        {
            if (day3_13_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_13_count--;
                }
            }

        }
        else if ((Clock.NowHour == 14) && (Clock.Day == 3))
        {
            if (day3_14_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_14_count--;
                }
            }

        }
        else if ((Clock.NowHour == 15) && (Clock.Day == 3))
        {
            if (day3_15_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_15_count--;
                }
            }

        }
        else if ((Clock.NowHour == 16) && (Clock.Day == 3))
        {
            if (day3_16_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_16_count--;
                }
            }

        }
        else if ((Clock.NowHour == 17) && (Clock.Day == 3))
        {
            if (day3_17_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_17_count--;
                }
            }

        }
        else if ((Clock.NowHour == 18) && (Clock.Day == 3))
        {
            if (day3_18_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_18_count--;
                }
            }

        }
        else if ((Clock.NowHour == 19) && (Clock.Day == 3))
        {
            if (day3_19_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_19_count--;
                }
            }

        }
        else if ((Clock.NowHour == 20) && (Clock.Day == 3))
        {
            if (day3_20_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_20_count--;
                }
            }

        }
        else if ((Clock.NowHour == 21) && (Clock.Day == 3))
        {
            if (day3_21_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_21_count--;
                }
            }

        }
        else if ((Clock.NowHour == 22) && (Clock.Day == 3))
        {
            if (day3_22_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_22_count--;
                }
            }

        }
        else if ((Clock.NowHour == 23) && (Clock.Day == 3))
        {
            if (day3_23_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_23_count--;
                }
            }

        }




    }
}
