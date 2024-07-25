using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Intro : MonoBehaviour
{
    public GameObject Intro1;

    public GameObject Intro2;
    public GameObject Intro3;
    public GameObject Intro4;
    public GameObject Intro5;
    public GameObject Intro6;

    public bool IsIntro1 = false;
    public bool IsIntro2 = false;
    public bool IsIntro3 = false;
    public bool IsIntro4 = false;
    public bool IsIntro5 = false;
    public bool IsIntro6 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Clock.Day == 1 && Clock.NowHour == 7 && !IsIntro1)
        {
            Intro1.SetActive(true);
            IsIntro1 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }

        else if(Clock.Day == 2 && Clock.NowHour == 3 && !IsIntro2)
        {
            Intro2.SetActive(true);
            IsIntro2 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }

        else if(Clock.Day == 3 && Clock.NowHour == 4 && !IsIntro3)
        {
            Intro3 .SetActive(true);
            IsIntro3 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }
        else if(Clock.Day == 4 && Clock.NowHour == 6 && !IsIntro4)
        {
            Intro4 .SetActive(true);
            IsIntro4 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }
        else if(Clock.Day == 4 && Clock.NowHour == 12 && !IsIntro5)
        {
            Intro5.SetActive(true);
            IsIntro5 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }
        else if(Clock.Day == 5 && Clock.NowHour == 6 && !IsIntro6)
        {
            Intro6.SetActive(true);
            IsIntro6 = true;
            Esc.pause = true;
            Time.timeScale = 0;
        }
        //else if(Clock.Day == 3 && Clock.NowHour)
    }
}
