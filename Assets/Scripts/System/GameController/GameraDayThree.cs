using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameraDayThree : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float m_timer = 0;
    Vector3 move = new Vector3();
    // Start is called before the first frame update
    void Start()
    {

        move.x -= 4;

    }

    // Update is called once per frame
    void Update()
    {

        if ((Clock.Day == 4) && (Clock.NowHour == 8))
        {
            m_timer += Time.deltaTime;
            if (m_timer <= 2f)
            {

                transform.position += move * Time.deltaTime;
                
            }
        }

    }
}