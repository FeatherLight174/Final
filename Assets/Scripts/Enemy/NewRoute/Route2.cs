using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Route2 : MonoBehaviour
{
    // Start is called before the first frame update

    private float Speed = 0.54f;

    public float PosX1 = 14;
    public float PosX2 = 13;
    public float PosX3 = 12;
    public float PosX4 = 3;
    public float PosX5 = 0;
    public float PosX6 = -2;


    public float PosY1 = -3;
    public float PosY2 = -5;
    public float PosY3 = -6;
    public float PosY4 = -5;
    public float PosY5 = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Clock.Day == 2)&&(Clock.NowHour >= 7)){
            if (gameObject.transform.position.x >= PosX1)
            {

                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= PosY1)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= PosX2)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= PosY2)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= PosX3)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= PosY3)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= PosX4)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= PosY4)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= PosX5)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.x >= PosY5)
            {
                gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y >= PosX6)
            {
                gameObject.transform.position -= Vector3.up * Speed * Time.deltaTime;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
