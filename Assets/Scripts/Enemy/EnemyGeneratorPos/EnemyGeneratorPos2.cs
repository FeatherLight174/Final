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
    private bool hasUp = false;
    private bool hasDown = false;

    // Day2
    private int day2_interval2 = 2
    private int day2_interval3 = 3;
    private int day2_interval4 = 4;

    private int day2_9_count = 3;
    private int day2_10_count = 3;
    private int day2_11_count = 3;
    private int day2_12_count = 3;
    private int day2_13_count = 3;
    private int day2_14_count = 3;
    private int day2_15_count = 3;
    private int day2_16_count = 3;
    private int day2_17_count = 3;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_timer2 += Time.deltaTime;
        if (Clock.NowHour == 18)
        {
            hasDown = false;
            if (hasUp == false)
            {
                GameConstant.EnemyMovespeed = GameConstant.EnemyMovespeed *= 2f;
                Debug.Log(GameConstant.EnemyMovespeed);
                GameConstant.EnemyAttack = GameConstant.EnemyAttack * 1.5f;
                GameConstant.EnemyMovespeed2 = GameConstant.EnemyMovespeed2 * 1.5f;
                GameConstant.EnemyAttack2 = GameConstant.EnemyAttack2 * 1.2f;
                hasUp = true;
            }

        }
        else if (Clock.NowHour == 5)
        {
            hasUp = false;
            if (hasDown == false)
            {
                GameConstant.EnemyMovespeed /= 2f;
                GameConstant.EnemyAttack /= 1.5f;
                GameConstant.EnemyMovespeed2 /= 1.5f;
                GameConstant.EnemyAttack2 /= 1.2f;
                hasDown = true;
            }

        }
        if ((Clock.NowHour == 9) && (Clock.Day == 2))
        {
            if (day2_9_count > 0)
            {
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
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
                if (m_timer >= day2_interval4)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day2_16_count--;
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



    }
}
