using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Clock : MonoBehaviour
{

    public AudioSource Night;
    private bool m_isNight = false;
    public AudioSource morning;
    private bool m_isMorning = false;
    public AudioSource Afternoon;
    private bool m_isAfter = false;
    
    public static float DayTime = 0;
    public static int Day = 2;
    public static int NowHour = 6;


    public float RedMin = 76;
    public float RedMax = 255;
    public float GreenMax = 255;
    public float GreenMin = 205;
    public float BlueMax = 255;
    public float BlueMin = 76;
    public float IntensityMax = 1;
    public float IntensityMin = 0.03f;

    private float m_nowRed;
    private float m_nowGreen;
    private float m_nowBlue;
    private float m_nowIntensity;

    private Light2D m_sunLight;
    

    void Start()
    {
        m_sunLight = GetComponent<Light2D>();
        m_nowRed = RedMin;
        m_nowGreen = GreenMax;
        m_nowBlue = BlueMax;
        m_nowIntensity = IntensityMin;
    }

    void Update()
    {
        if(NowHour == 22 && !m_isNight)
        {
            Night.Play();
            Afternoon.Pause();
            m_isNight = true;
        }
        else if(NowHour == 13 && !m_isAfter)
        {
            Afternoon.Play();
            morning.Pause();
            m_isAfter = true;
        }
        else if(NowHour == 7 && !m_isMorning)
        {
            morning.Play();
            m_isMorning = true;
        }
        DayTime += Time.deltaTime;
        if (DayTime >= GameConstant.HourTime)
        {
            NowHour++;
            
            DayTime = 0;
            if (NowHour == 24)
            {
                Day++;
                m_isAfter = false;
                m_isMorning = false;
                m_isNight = false;
                NowHour = 0;
            }
        }

        UpdateLightProperties();

        m_sunLight.color = new Color(m_nowRed / 255, m_nowGreen / 255, m_nowBlue / 255, 1);
        m_sunLight.intensity = m_nowIntensity;
        //Debug.Log(m_sunLight.color + " " + NowHour);
    }

    void UpdateLightProperties()
    {
        // Blue color transition
        if (NowHour >= 20 || NowHour <= 6)
        {
            m_nowBlue = BlueMax;
        }
        else if (NowHour >= 7 && NowHour <= 10)
        {
            m_nowBlue = Mathf.Lerp(m_nowBlue, BlueMin, Time.deltaTime / (GameConstant.HourTime * 4));
        }
        else if (NowHour > 10 && NowHour <= 18)
        {
            m_nowBlue = BlueMin;
        }
        else if (NowHour >= 19 && NowHour <= 20)
        {
            m_nowBlue = Mathf.Lerp(m_nowBlue, BlueMax, Time.deltaTime / GameConstant.HourTime);
        }

        // Red color transition
        if (NowHour >= 7 && NowHour < 12)
        {
            m_nowRed = Mathf.Lerp(m_nowRed, RedMax, Time.deltaTime / (4 * GameConstant.HourTime));
        }
        else if (NowHour >= 20 || NowHour <= 6)
        {
            m_nowRed = RedMin;
        }
        else if (NowHour >= 13 && m_nowRed >= RedMin && NowHour < 18)
        {
            m_nowRed = RedMax;
        }
        else if (NowHour >= 18 && NowHour < 20)
        {
            m_nowRed = Mathf.Lerp(m_nowRed, RedMin, Time.deltaTime / (2 * GameConstant.HourTime));
        }

        // Green color transition
        if (NowHour > 16 || NowHour < 11)
        {
            m_nowGreen = GreenMax;
        }
        else if (NowHour >= 11 && NowHour <= 12)
        {
            m_nowGreen = Mathf.Lerp(m_nowGreen, GreenMin, Time.deltaTime / (2 * GameConstant.HourTime));
        }
        else if (NowHour > 12 && NowHour < 15)
        {
            m_nowGreen = GreenMin;
        }
        else if (NowHour >= 15 && NowHour <= 16)
        {
            m_nowGreen = Mathf.Lerp(m_nowGreen, GreenMax, Time.deltaTime / (2 * GameConstant.HourTime));
        }

        // Intensity transition
        if (NowHour >= 6 && NowHour <= 8)
        {
            m_nowIntensity = Mathf.Lerp(m_nowIntensity, IntensityMax, Time.deltaTime / (3 * GameConstant.HourTime));
        }
        else if (NowHour > 8 && NowHour < 18)
        {
            m_nowIntensity = IntensityMax;
        }
        else if (NowHour >= 18 || NowHour <= 20)
        {
            m_nowIntensity = Mathf.Lerp(m_nowIntensity, IntensityMin, Time.deltaTime / (3 * GameConstant.HourTime));
        }
        else if (NowHour > 20 || NowHour < 5)
        {
            m_nowIntensity = IntensityMin;
        }
    }
}
