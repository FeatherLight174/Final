using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject boom;
    private float m_timer = 0;
    // Start is called before the first frame update
    private bool AudioIsPlaying = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Clock.Day == 2)&&(Clock.NowHour == 8))
        {
            m_timer += Time.deltaTime;
            if(m_timer >= 5)
            {
                boom.SetActive(true);
                if (!AudioIsPlaying && m_timer >= 5.24f)
                {
                    AudioIsPlaying = true;
                    GetComponent<AudioSource>().Play();
                }
                    
            }
            if(m_timer >= 6)
            {
                boom.SetActive(false);
            }
        }
    }
}
