using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject[] enemy;
    public float TimerMorning = 1;
    public float TimerAfternoon = 1;
    public float TimerNight = 1;
    public float TimerDawn = 1;
    public float factor = 0.5f;
    private float m_timer = 0;

    // Day1

    private int day1_9_count = 1;
    private int day1_11_count = 2;
    private int day1_11_interval = 1;
    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;

        if (Clock.NowHour == 9)
        {
            if (day1_9_count > 0)
            {
                Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                m_timer = 0;
                day1_9_count--;
            }

        }
        else if (Clock.NowHour == 11)
        {
            if (day1_11_count > 0)
            {
                if (m_timer >= day1_11_interval)
                {
                    Instantiate(enemy[0], gameObject.transform.position, Quaternion.identity);
                    m_timer = 0;
                    day1_11_count--;
                }
            }

        }

    }


}