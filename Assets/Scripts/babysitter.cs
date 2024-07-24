using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babysitter : MonoBehaviour
{
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Clock.Day == 2)&&(Clock.NowHour == 6)){
            tower.SetActive(true);
        }
    }
}
