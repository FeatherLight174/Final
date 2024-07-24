using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos3 : MonoBehaviour
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

    private int day2_9_count = 1;
    private int day2_10_count = 1;
    private int day2_11_count = 1;
    private int day2_12_count = 1;
    private int day2_13_count = 1;
    private int day2_14_count = 1;
    private int day2_15_count = 2;
    private int day2_16_count = 2;
    private int day2_16_count_2 = 1;
    private int day2_17_count = 2;


    private int day2_19_count = 1;
    private int day2_20_count = 2;
    private int day2_21_count = 1;
    private int day2_22_count = 2;
    private int day2_23_count = 1;

    // day3
    private int day3_0_count = 2;
    private int day3_1_count = 2;
    private int day3_2_count = 2;
    private int day3_3_count_2 = 1;
    private int day3_4_count = 3;
    private int day3_4_count_2 = 1;
    private int day3_5_count = 2;

    private int day3_6_count = 3;
    private int day3_7_count = 2;
    private int day3_8_count = 1;
    private int day3_9_count_2 = 1;
    private int day3_10_count = 2;
    private int day3_11_count = 1;

    private int day3_12_count_3 = 1;
    private int day3_13_count = 7;
    private int day3_14_count_3 = 1;
    private int day3_15_count = 7;
    private int day3_16_count_3 = 1;
    private int day3_17_count_3 = 1;

    private int day3_18_count = 6;
    private int day3_19_count_2 = 1;
    private int day3_20_count = 6;
    private int day3_21_count_2 = 1;
    private int day3_22_count = 6;
    private int day3_23_count_2 = 1;

    // Day4
    private int day4_0_count = 2;
    private int day4_1_count = 2;
    private int day4_2_count_2 = 2;
    private int day4_3_count_2 = 2;
    private int day4_4_count_2 = 2;
    private int day4_5_count_2 = 2;

    private int day4_6_count = 1;
    private int day4_7_count = 5;
    private int day4_8_count = 1;
    private int day4_9_count = 5;
    private int day4_10_count = 1;
    private int day4_11_count = 5;

    private int day4_12_count = 4;
    private int day4_13_count = 6;
    private int day4_14_count = 6;
    private int day4_15_count = 4;
    private int day4_16_count = 4;
    private int day4_17_count = 6;

    private int day4_18_count = 2;
    private int day4_19_count = 2;
    private int day4_20_count = 2;
    private int day4_21_count = 2;
    private int day4_22_count = 6;
    private int day4_23_count = 0;

    private int day5_0_count = 0;
    private int day5_1_count = 0;
    private int day5_2_count = 0;
    private int day5_3_count = 0;
    private int day5_4_count = 0;
    private int day5_5_count = 0;
    private int day5_6_count = 0;
    private int day5_7_count = 0;

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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_2_count--;
                }
            }

        }
        else if ((Clock.NowHour == 3) && (Clock.Day == 3))
        {
            if (day3_3_count_2 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_3_count_2--;
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
            if (day3_4_count_2 > 0)
            {
                if (m_timer2 >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer2 = 0;
                    day3_4_count_2--;
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
                if (m_timer >= day2_interval4)
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
            if (day3_12_count_3 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_12_count_3--;
                }
            }

        }
        else if ((Clock.NowHour == 13) && (Clock.Day == 3))
        {
            if (day3_13_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_13_count--;
                }
            }

        }
        else if ((Clock.NowHour == 14) && (Clock.Day == 3))
        {
            if (day3_14_count_3 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_14_count_3--;
                }
            }

        }
        else if ((Clock.NowHour == 15) && (Clock.Day == 3))
        {
            if (day3_15_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_15_count--;
                }
            }

        }
        else if ((Clock.NowHour == 16) && (Clock.Day == 3))
        {
            if (day3_16_count_3 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_16_count_3--;
                }
            }

        }
        else if ((Clock.NowHour == 17) && (Clock.Day == 3))
        {
            if (day3_17_count_3 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[2], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_17_count_3--;
                }
            }

        }
        else if ((Clock.NowHour == 18) && (Clock.Day == 3))
        {
            if (day3_18_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_18_count--;
                }
            }

        }
        else if ((Clock.NowHour == 19) && (Clock.Day == 3))
        {
            if (day3_19_count_2 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_19_count_2--;
                }
            }

        }
        else if ((Clock.NowHour == 20) && (Clock.Day == 3))
        {
            if (day3_20_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_20_count--;
                }
            }

        }
        else if ((Clock.NowHour == 21) && (Clock.Day == 3))
        {
            if (day3_21_count_2 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_21_count_2--;
                }
            }

        }
        else if ((Clock.NowHour == 22) && (Clock.Day == 3))
        {
            if (day3_22_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_22_count--;
                }
            }

        }
        else if ((Clock.NowHour == 23) && (Clock.Day == 3))
        {
            if (day3_23_count_2 > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day3_23_count_2--;
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
                if (m_timer >= 7)
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
                if (m_timer >= 7)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_3_count_2--;
                }
            }

        }
        else if ((Clock.NowHour == 4) && (Clock.Day == 4))
        {
            if (day4_4_count_2 > 0)
            {
                if (m_timer >= 7)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_4_count_2--;
                }
            }

        }
        else if ((Clock.NowHour == 5) && (Clock.Day == 4))
        {
            if (day4_5_count_2 > 0)
            {
                if (m_timer >= 7)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_5_count_2--;
                }
            }

        }
        else if ((Clock.NowHour == 6) && (Clock.Day == 4))
        {
            if (day4_6_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_6_count--;
                }
            }

        }
        else if ((Clock.NowHour == 7) && (Clock.Day == 4))
        {
            if (day4_7_count > 0)
            {
                if (m_timer >= 1)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
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
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_8_count--;
                }
            }

        }
        else if ((Clock.NowHour == 9) && (Clock.Day == 4))
        {
            if (day4_9_count > 0)
            {
                if (m_timer >= 1)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
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
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_10_count--;
                }
            }

        }
        else if ((Clock.NowHour == 11) && (Clock.Day == 4))
        {
            if (day4_11_count > 0)
            {
                if (m_timer >= 1)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_11_count--;
                }
            }

        }
        else if ((Clock.NowHour == 12) && (Clock.Day == 4))
        {
            if (day4_12_count > 0)
            {
                if (m_timer >= 1)
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
                if (m_timer >= 0.5f)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_13_count--;
                }
            }

        }
        else if ((Clock.NowHour == 14) && (Clock.Day == 4))
        {
            if (day4_14_count > 0)
            {
                if (m_timer >= 0.5f)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_14_count--;
                }
            }

        }
        else if ((Clock.NowHour == 15) && (Clock.Day == 4))
        {
            if (day4_15_count > 0)
            {
                if (m_timer >= 1)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_15_count--;
                }
            }

        }
        else if ((Clock.NowHour == 16) && (Clock.Day == 4))
        {
            if (day4_16_count > 0)
            {
                if (m_timer >= 1)
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
                if (m_timer >= 0.5f)
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
                if (m_timer >= 2)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_18_count--;
                }
            }

        }
        else if ((Clock.NowHour == 19) && (Clock.Day == 4))
        {
            if (day4_19_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_19_count--;
                }
            }

        }
        else if ((Clock.NowHour == 20) && (Clock.Day == 4))
        {
            if (day4_20_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_20_count--;
                }
            }

        }
        else if ((Clock.NowHour == 21) && (Clock.Day == 4))
        {
            if (day4_21_count > 0)
            {
                if (m_timer >= 2)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_21_count--;
                }
            }

        }
        else if ((Clock.NowHour == 22) && (Clock.Day == 4))
        {
            if (day4_22_count > 0)
            {
                if (m_timer >= 1)
                {
                    Instantiate(enemy[1], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_22_count--;
                }
            }

        }
        else if ((Clock.NowHour == 23) && (Clock.Day == 4))
        {
            if (day4_23_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_23_count--;
                }
            }

        }



    }
}
