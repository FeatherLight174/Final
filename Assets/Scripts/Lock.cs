using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock :MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
// Start is called before the first frame update


// Update is called once per frame
    void Update()
    {
        if ((Clock.Day == 2) && (Clock.NowHour == 6))
        {
            panel1.SetActive(true);
            panel2.SetActive(true);
        }
        else if ((Clock.Day == 3) && (Clock.NowHour == 6))
        {
            panel3.SetActive(true);
        }
    }
}
