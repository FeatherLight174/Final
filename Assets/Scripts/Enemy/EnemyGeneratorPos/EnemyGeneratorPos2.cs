using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos2 : MonoBehaviour
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


    // Day2
    private int day2_interval2 = 2;
    private int day2_interval3 = 3;
    private int day2_interval4 = 4;
    private int day2_interval5 = 5;

    private int day2_9_count = 2;
    private int day2_10_count = 2;
    private int day2_11_count = 2;
    private int day2_12_count = 2;
    private int day2_13_count = 2;
    private int day2_14_count = 2;
    private int day2_15_count = 4;
    private int day2_16_count = 2;
    private int day2_16_count_2 = 1;
    private int day2_17_count = 2;


    private int day2_19_count = 2;
    private int day2_20_count = 2;
    private int day2_20_count_2 = 1;
    private int day2_21_count = 3;
    private int day2_22_count = 1;
    private int day2_22_count_2 = 1;
    private int day2_23_count = 2;

    // day3
    private int day3_0_count = 0;
    private int day3_1_count = 0;
    private int day3_2_count = 0;
    private int day3_3_count = 0;
    private int day3_4_count = 0;
    private int day3_5_count = 0;

    private int day3_6_count = 0;
    private int day3_7_count = 0;
    private int day3_8_count = 0;
    private int day3_9_count = 0;
    private int day3_10_count = 0;
    private int day3_11_count = 0;

    private int day3_12_count = 0;
    private int day3_13_count = 0;
    private int day3_14_count = 0;
    private int day3_15_count = 0;
    private int day3_16_count = 0;
    private int day3_17_count = 0;

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

        if ((Clock.NowHour == 9) && (Clock.Day == 2))
        {
            if (day2_9_count > 0)
            {
                if (m_timer >= day2_interval5)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_9_count--;
                }
            }
        }
        else if ((Clock.NowHour == 10) && (Clock.Day == 2))
        {
            if (day2_10_count > 0)
            {
                if (m_timer >= day2_interval5)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_10_count--;
                }
            }

        }
        else if ((Clock.NowHour == 11) && (Clock.Day == 2))
        {
            if (day2_11_count > 0)
            {
                if (m_timer >= day2_interval5)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_11_count--;
                }
            }

        }
        else if ((Clock.NowHour == 12) && (Clock.Day == 2))
        {
            if (day2_12_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_12_count--;
                }
            }

        }
        else if ((Clock.NowHour == 13) && (Clock.Day == 2))
        {
            if (day2_13_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_13_count--;
                }
            }

        }
        else if ((Clock.NowHour == 14) && (Clock.Day == 2))
        {
            if (day2_14_count > 0)
            {
                if (m_timer >= day2_interval2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_14_count--;
                }
            }

        }
        else if ((Clock.NowHour == 15) && (Clock.Day == 2))
        {
            if (day2_15_count > 0)
            {
                if (m_timer >= day2_interval3)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_15_count--;
                }
            }

        }
        else if ((Clock.NowHour == 16) && (Clock.Day == 2))
        {
            if (day2_16_count > 0)
            {
                if (m_timer >= day2_interval5)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_16_count--;
                }
            
            }
            if (day2_16_count_2 > 0)
            {
                if (m_timer2 >= day2_interval5)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer2 = 0;
                    day2_16_count_2--;
                }

            }

        }
        else if ((Clock.NowHour == 17) && (Clock.Day == 2))
        {
            if (day2_17_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_17_count--;
                }
            }

        }
        else if ((Clock.NowHour == 19) && (Clock.Day == 2))
        {
            if (day2_19_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_19_count--;
                }
            }

        }
        else if ((Clock.NowHour == 20) && (Clock.Day == 2))
        {
            if (day2_20_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_20_count--;
                }
                if (m_timer2 >= day2_interval7)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer2 = 0;
                    day2_20_count_2--;
                }
            }

        }
        else if ((Clock.NowHour == 21) && (Clock.Day == 2))
        {
            if (day2_21_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_21_count--;
                }

            }

        }
        else if ((Clock.NowHour == 22) && (Clock.Day == 2))
        {
            if (day2_22_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_22_count--;
                }
            }
            if (m_timer2 >= day2_interval5)
            {
                Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day2_22_count_2--;
            }

        }
        else if ((Clock.NowHour == 23) && (Clock.Day == 2))
        {
            if (day2_23_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_23_count--;
                }
            }

        }




    }
}
