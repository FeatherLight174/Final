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
    private int day2_interval = 1;
    private int day2_interval2 = 2;
    private int day2_interval3 = 3;
    private int day2_interval4 = 4;
    private int day2_interval5 = 5;
    private int day2_interval7 = 7;

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
    private int day3_0_count = 3;
    private int day3_1_count = 4;
    private int day3_2_count = 3;
    private int day3_3_count = 4;
    private int day3_4_count = 3;
    private int day3_5_count = 0;

    private int day3_6_count = 3;
    private int day3_7_count = 2;
    private int day3_8_count = 1;
    private int day3_9_count_2 = 2;
    private int day3_10_count = 3;
    private int day3_11_count = 3;

    private int day3_12_count = 3;
    private int day3_13_count_2 = 2;
    private int day3_14_count = 3;
    private int day3_15_count_2 = 2;
    private int day3_16_count = 3;
    private int day3_17_count_2 = 2;

    private int day3_18_count = 10;
    private int day3_19_count = 10;
    private int day3_20_count = 10;
    private int day3_21_count = 10;
    private int day3_22_count = 10;
    private int day3_23_count = 10;

    // Day4
    private int day4_0_count = 4;
    private int day4_1_count = 4;
    private int day4_2_count_2 = 3;
    private int day4_3_count_2 = 3;
    private int day4_4_count = 2;
    private int day4_5_count = 2;

    private int day4_6_count = 0;
    private int day4_7_count = 1;
    private int day4_8_count = 0;
    private int day4_9_count = 1;
    private int day4_10_count = 0;
    private int day4_11_count = 1;

    private int day4_12_count = 5;
    private int day4_13_count = 5;
    private int day4_14_count_2 = 2;
    private int day4_14_count2_2 = 1;
    private int day4_15_count_2 = 2;
    private int day4_15_count2_2 = 1;
    private int day4_16_count = 8;
    private int day4_17_count = 8;

    private int day4_18_count = 8;
    private int day4_19_count_2 = 2;
    private int day4_20_count = 6;
    private int day4_21_count_2 = 1;
    private int day4_22_count = 8;
    private int day4_23_count_2 = 2;

    private int day5_0_count = 0;
    private int day5_1_count = 0;
    private int day5_2_count_2 = 4;
    private int day5_3_count = 0;
    private int day5_4_count = 0;
    private int day5_5_count_2 = 2;
    private int day5_6_count = 2;
    private int day5_7_count = 0;

    private bool dayOutOfRange = false;

    private int hour0count_3 = 1;
    private int hour0count_4 = 1;
    private int hour1count_3 = 1;
    private int hour2count_3 = 1;
    private int hour3count_3 = 1;
    private int hour4count_3 = 1;
    private int hour5count_3 = 1;
    private int hour6count_3 = 1;
    private int hour7count_3 = 1;

    private int hour8count_3 = 0;
    private int hour9count_3 = 0;
    private int hour10count_3 = 3;
    private int hour11count_3 = 3;
    private int hour12count_3 = 0;
    private int hour13count_3 = 0;
    private int hour14count_3 = 0;
    private int hour15count_3 = 0;
    private int hour16count_3 = 0;
    private int hour17count_3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Clock.Day == 5) && (Clock.NowHour == 8)){
            dayOutOfRange = true;
        }
        m_timer += Time.deltaTime;
        m_timer2 += Time.deltaTime;

        if (!dayOutOfRange)
        {
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

                }
                if (day2_20_count_2 > 0)
                {
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
                if (day2_22_count_2 > 0)
                {
                    if (m_timer2 >= day2_interval5)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day2_22_count_2--;
                    }
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
            else if ((Clock.NowHour == 0) && (Clock.Day == 3))
            {
                if (day3_0_count > 0)
                {
                    if (m_timer >= day2_interval3)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_0_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 1) && (Clock.Day == 3))
            {
                if (day3_1_count > 0)
                {
                    if (m_timer >= day2_interval)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_1_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 2) && (Clock.Day == 3))
            {
                if (day3_2_count > 0)
                {
                    if (m_timer >= day2_interval3)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_2_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 3) && (Clock.Day == 3))
            {
                if (day3_3_count > 0)
                {
                    if (m_timer >= day2_interval)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_3_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 4) && (Clock.Day == 3))
            {
                if (day3_4_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_4_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 5) && (Clock.Day == 3))
            {
                if (day3_5_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_5_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 6) && (Clock.Day == 3))
            {
                if (day3_6_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_6_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 7) && (Clock.Day == 3))
            {
                if (day3_7_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_7_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 8) && (Clock.Day == 3))
            {
                if (day3_8_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_8_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 9) && (Clock.Day == 3))
            {
                if (day3_9_count_2 > 0)
                {
                    if (m_timer >= day2_interval7)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_9_count_2--;
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
                if (day3_13_count_2 > 0)
                {
                    if (m_timer >= 5)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_13_count_2--;
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
                if (day3_15_count_2 > 0)
                {
                    if (m_timer >= 5)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_15_count_2--;
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
                if (day3_17_count_2 > 0)
                {
                    if (m_timer >= 5)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_17_count_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 18) && (Clock.Day == 3))
            {
                if (day3_18_count > 0)
                {
                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_18_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 19) && (Clock.Day == 3))
            {
                if (day3_19_count > 0.5f)
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
                if (day3_20_count > 0.5f)
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
                if (day3_21_count > 1)
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
                if (day3_22_count > 1)
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
                if (day3_23_count > 0.5f)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day3_23_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 0) && (Clock.Day == 4))
            {
                if (day4_0_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_0_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 1) && (Clock.Day == 4))
            {
                if (day4_1_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_1_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 2) && (Clock.Day == 4))
            {
                if (day4_2_count_2 > 0)
                {
                    if (m_timer >= 4.5f)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_2_count_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 3) && (Clock.Day == 4))
            {
                if (day4_3_count_2 > 0)
                {
                    if (m_timer >= 4.5f)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_3_count_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 4) && (Clock.Day == 4))
            {
                if (day4_4_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_4_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 5) && (Clock.Day == 4))
            {
                if (day4_5_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_5_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 6) && (Clock.Day == 4))
            {
                if (day4_6_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_6_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 7) && (Clock.Day == 4))
            {
                if (day4_7_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_7_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 8) && (Clock.Day == 4))
            {
                if (day4_8_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_8_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 9) && (Clock.Day == 4))
            {
                if (day4_9_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_9_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 10) && (Clock.Day == 4))
            {
                if (day4_10_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_10_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 11) && (Clock.Day == 4))
            {
                if (day4_11_count > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_11_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 12) && (Clock.Day == 4))
            {
                if (day4_12_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_12_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 13) && (Clock.Day == 4))
            {
                if (day4_13_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_13_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 14) && (Clock.Day == 4))
            {
                if (day4_14_count_2 > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_14_count_2--;
                    }
                }
                else if (day4_14_count2_2 > 0)
                {
                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_14_count2_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 15) && (Clock.Day == 4))
            {
                if (day4_15_count_2 > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_15_count_2--;
                    }
                }
                else if (day4_15_count2_2 > 0)
                {
                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_15_count2_2--;
                    }
                }
            }
            else if ((Clock.NowHour == 16) && (Clock.Day == 4))
            {
                if (day4_16_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_16_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 17) && (Clock.Day == 4))
            {
                if (day4_17_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_17_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 18) && (Clock.Day == 4))
            {
                if (day4_18_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_18_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 19) && (Clock.Day == 4))
            {
                if (day4_19_count_2 > 0)
                {
                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_19_count_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 20) && (Clock.Day == 4))
            {
                if (day4_20_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_20_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 21) && (Clock.Day == 4))
            {
                if (day4_21_count_2 > 0)
                {
                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_21_count_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 22) && (Clock.Day == 4))
            {
                if (day4_22_count > 0)
                {
                    if (m_timer >= 1.5f)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_22_count--;
                    }
                }

            }
            else if ((Clock.NowHour == 23) && (Clock.Day == 4))
            {
                if (day4_23_count_2 > 0)
                {
                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day4_23_count_2--;
                    }
                }

            }
            else if ((Clock.NowHour == 0) && (Clock.Day == 5))
            {
                if (day5_0_count > 0)
                {

                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day5_0_count--;
                    }


                }

            }
            else if ((Clock.NowHour == 1) && (Clock.Day == 5))
            {
                if (day5_1_count > 0)
                {

                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day5_1_count--;
                    }


                }

            }
            else if ((Clock.NowHour == 2) && (Clock.Day == 5))
            {
                if (day5_2_count_2 > 0)
                {

                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day5_2_count_2--;
                    }


                }

            }
            else if ((Clock.NowHour == 3) && (Clock.Day == 5))
            {
                if (day5_3_count > 0)
                {

                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day5_3_count--;
                    }


                }

            }
            else if ((Clock.NowHour == 4) && (Clock.Day == 5))
            {
                if (day5_4_count > 0)
                {

                    if (m_timer >= day2_interval4)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day5_4_count--;
                    }


                }

            }
            else if ((Clock.NowHour == 5) && (Clock.Day == 5))
            {
                if (day5_5_count_2 > 0)
                {

                    if (m_timer >= 5)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        day5_5_count_2--;
                    }


                }

            }
        }
        else
        {
            if (Clock.NowHour == 0)
            {
                
    hour1count_3 = 1;
    hour2count_3 = 1;
    hour3count_3 = 1;
    hour4count_3 = 1;
    hour5count_3 = 1;
    hour6count_3 = 1;
    hour7count_3 = 1;

    hour8count_3 = 0;
    hour9count_3 = 0;
    hour10count_3 = 4;
    hour11count_3 = 4;
    hour12count_3 = 0;
    hour13count_3 = 0;
    hour14count_3 = 0;
    hour15count_3 = 0;
    hour16count_3 = 0;
    hour17count_3 = 0;
                if (hour0count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour0count_3--;
                    }
                }
                if (hour0count_4 > 0)
                {
                    if (m_timer2 >= 2)
                    {
                        Instantiate(enemy[4], gameObject.transform.position, Quaternion.identity);
                        m_timer2 = 0;
                        hour0count_4--;
                    }
                }
            }
            else if (Clock.NowHour == 1)
            {
    hour0count_3 = 1;
    hour0count_4 = 1;
                if (hour1count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour1count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 2)
            {
                if (hour2count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour2count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 3)
            {
                if (hour3count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour3count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 4)
            {
                if (hour4count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour4count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 5)
            {
                if (hour5count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour5count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 6)
            {
                if (hour6count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour6count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 7)
            {
                if (hour7count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour7count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 8)
            {
                if (hour8count_3 > 0)
                {
                    if (m_timer >= 1)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour8count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 9)
            {
                if (hour9count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour9count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 10)
            {
                if (hour10count_3 > 0)
                {
                    if (m_timer >= 3)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour10count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 11)
            {
                if (hour11count_3 > 0)
                {
                    if (m_timer >= 3)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour11count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 12)
            {
                if (hour12count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour12count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 13)
            {
                if (hour13count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour13count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 14)
            {
                if (hour14count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour14count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 15)
            {
                if (hour15count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour15count_3--;
                    }
                }
            }
            else if (Clock.NowHour == 16)
            {
                if (hour16count_3 > 0)
                {
                    if (m_timer >= 2)
                    {
                        Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                        m_timer = 0;
                        hour16count_3--;
                    }
                }
            }
        }

    }
}
