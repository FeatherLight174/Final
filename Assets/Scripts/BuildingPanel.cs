using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    public GameObject Intro1;
    public GameObject Intro2;
    public GameObject Intro3;
    public GameObject Intro4;
    public GameObject Intro5;
    public GameObject Intro6;
    public GameObject Intro7;
    private float m_timer = 0;

    public bool IsIntro1 = false;
    public bool IsIntro2 = false;
    public bool IsIntro3 = false;
    public bool IsIntro4 = false;
    public bool IsIntro5 = false;
    public bool IsIntro6 = false;
    public bool IsIntro7 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.timeScale;
        if (Clock.Day == 1 && Clock.NowHour == 6 && !IsIntro7)
        {
            if (m_timer >= 1f)
            {
                Intro7.SetActive(true);
                IsIntro7 = true;
                Esc.pause = true;
                Time.timeScale = 0;
                m_timer = 0;
            }

        }
        else if (Clock.Day == 1 && Clock.NowHour == 6 && !IsIntro1 && IsIntro7)
        {
            if (m_timer >= 1f)
            {
                Intro1.SetActive(true);
                IsIntro1 = true;
                Esc.pause = true;
                Time.timeScale = 0;
                m_timer = 0;
            }
                
        }

        else if (Clock.Day == 1 && Clock.NowHour == 6 && !IsIntro2 && IsIntro1 && IsIntro7)
        {
            if(m_timer >= 1f)
            {
                Intro2.SetActive(true);
                IsIntro2 = true;
                Esc.pause = true;
                Time.timeScale = 0;
                m_timer = 0;
            }
            
        }

        else if (Clock.Day == 1 && Clock.NowHour == 6 && !IsIntro3 && IsIntro2 && IsIntro1 && IsIntro7)
        {
            if (m_timer >= 1f)
            {
                Intro3.SetActive(true);
                IsIntro3 = true;
                Esc.pause = true;
                Time.timeScale = 0;
                m_timer = 0;
            }
                
        }
        else if (Clock.Day == 2 && Clock.NowHour == 6 && !IsIntro4)
        {
            Intro4.SetActive(true);
            IsIntro4 = true;
            Esc.pause = true;
            Time.timeScale = 0;
            m_timer = 0;
        }
        else if (Clock.Day == 2 && Clock.NowHour == 6 && !IsIntro5 && IsIntro4)
        {
            if (m_timer >= 1f)
            {
                Intro5.SetActive(true);
                IsIntro5 = true;
                Esc.pause = true;
                Time.timeScale = 0;
            }
                
        }
        else if (Clock.Day == 3 && Clock.NowHour == 6 && !IsIntro6)
        {
            Intro6.SetActive(true);
            IsIntro6 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }
    }
}
