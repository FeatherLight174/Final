using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    public static bool pause = false;
    public static bool twice = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(pause)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (twice)
            {
                twice = false;

            }
            else
            {
                twice= true;
            }
        }
        if (pause&&twice)
        {
            Time.timeScale = 0;
        }
        else if (pause && !twice)
        {
            Time.timeScale = 0;
        }
        else if (!pause && twice)
        {
            Time.timeScale = 2;
        }
        else if(!pause && !twice)
        {
            Time.timeScale = 1;
        }
        
        
    }
}
