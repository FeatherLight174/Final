using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameraDayTwo : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float m_timer = 0;
    Vector3 move = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
        move.x += 4;
        move.y -= 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Clock.Day == 2)&&(Clock.NowHour == 6))
        {
            m_timer += Time.deltaTime;
            if (m_timer <= 1)
            {
                Debug.Log("move");
                transform.position += move * Time.deltaTime;
                Camera.main.orthographicSize += 2 * Time.deltaTime;
            }
        }
    }
}
