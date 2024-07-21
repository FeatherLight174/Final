using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Clock : MonoBehaviour
{
    public static float DayTime = 0;
    public static int Day = 0;
    public static int NowHour = 0;

    public float RedMin = 76;
    public float RedMax = 255;
    public float GreenMax = 235;
    public float GreenMin = 205;
    public float BlueMax = 255;
    public float BlueMin = 76;

    private float m_nowRed = 76;
    private float m_nowGreen = 246;
    private float m_nowBlue = 255;

    private Light2D m_sunLight;

    // Start is called before the first frame update
    void Start()
    {
        m_sunLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DayTime += Time.deltaTime;
        if (DayTime >= GameConstant.HourTime)
        {

            NowHour++;
            if(NowHour >= 20 || NowHour <= 6)
            {
                m_nowBlue = 255;
            }
            //else if(NowHour >= 7 && NowHour  )
            else if(NowHour > 10 && NowHour <=18)
            {
                m_nowBlue = BlueMin; 
            }
            else if(NowHour >= 19 && NowHour <= 20)
            {
                m_nowBlue += Time.deltaTime / GameConstant.HourTime * (BlueMax - BlueMin);
            }
            if(NowHour >= 7 && m_nowRed <= 255 && NowHour < 12)
            {
                m_nowRed += Time.deltaTime / (4 * GameConstant.HourTime)*(RedMax - RedMin);
            }
            else if(NowHour >= 13 && m_nowRed >= RedMin && NowHour < 18)
            {
                m_nowRed = RedMax;
            }
            else if(NowHour >= 18)
            DayTime = 0;
            if(NowHour == 24)
            {
                Day++;
                NowHour = 0;
            }

        }
    }
}
