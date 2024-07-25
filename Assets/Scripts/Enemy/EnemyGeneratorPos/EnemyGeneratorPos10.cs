using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorPos10 : MonoBehaviour
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
    private int day2_interval2 = 2;
    private int day2_interval3 = 3;
    private int day2_interval4 = 4;
    private int day2_interval5 = 5;

    private int day4_6_count = 0;
    private int day4_7_count = 0;
    private int day4_8_count = 0;
    private int day4_9_count = 0;
    private int day4_10_count = 0;
    private int day4_11_count = 0;

    private int day4_12_count = 0;
    private int day4_13_count = 0;
    private int day4_14_count = 0;
    private int day4_15_count = 0;
    private int day4_16_count = 0;
    private int day4_17_count = 0;

    private int day4_18_count = 0;
    private int day4_19_count = 0;
    private int day4_20_count = 0;
    private int day4_21_count = 0;
    private int day4_22_count = 0;
    private int day4_23_count = 0;

    private int day5_0_count = 0;
    private int day5_1_count = 0;
    private int day5_2_count = 0;
    private int day5_3_count = 0;
    private int day5_4_count = 0;
    private int day5_5_count = 1;
    private int day5_6_count = 0;
    private int day5_7_count = 0;

    private int day5_8_count = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_timer2 += Time.deltaTime;




        if ((Clock.NowHour == 6) && (Clock.Day == 4))
        {
            if (day4_6_count > 0)
            {
                if (m_timer >= 2)
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
                if (m_timer >= 2)
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
                if (m_timer >= 2)
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
                if (m_timer >= 2)
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
                if (m_timer >= 2)
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
                if (m_timer >= 2)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_18_count--;
                }
            }

        }
        else if ((Clock.NowHour == 19) && (Clock.Day == 4))
        {
            if (day4_19_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_19_count--;
                }
            }

        }
        else if ((Clock.NowHour == 20) && (Clock.Day == 4))
        {
            if (day4_20_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_20_count--;
                }
            }

        }
        else if ((Clock.NowHour == 21) && (Clock.Day == 4))
        {
            if (day4_21_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day4_21_count--;
                }
            }

        }
        else if ((Clock.NowHour == 22) && (Clock.Day == 4))
        {
            if (day4_22_count > 0)
            {
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
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
            if (day5_2_count > 0)
            {

                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day5_2_count--;
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
            if (day5_5_count > 0)
            {

                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day5_5_count--;
                }


            }

        }
        else if ((Clock.NowHour == 8) && (Clock.Day == 5))
        {
            if (day5_5_count > 0)
            {

                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day5_5_count--;
                }


            }

        }


    }
}
