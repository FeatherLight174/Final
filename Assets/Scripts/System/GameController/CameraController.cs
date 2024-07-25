using UnityEngine;

public class CameraController : MonoBehaviour
{
    private  float moveSpeed = 10f; // 控制摄像机移动速度
    private bool enable = false;
    private bool isborder = false;

    void Update()
    {
        if((transform.position.x <= -12)||(transform.position.x >=2)||(transform.position.y <= -7)||(transform.position.y >= -2))
        {
            isborder = true;
        }
        else
        {
            isborder= false;
        }
        Vector3 move = new Vector3();




        // 检测WASD键输入
        if((Clock.Day >=3)&&(Clock.NowHour >= 6))
        {
            enable = true;
        }


        if (isborder)
        {
            if ((transform.position.x <= -12))
            {
                move.x += 1;
            }
            else if(transform.position.x >= 2)
            {
                move.x -= 1;
            }
            else if(transform.position.y <= -7)
            {
                move.y += 1;
            }
            else if(transform.position.y >= -2)
            {
                move.y -= 1;
            }
        }


        if (enable&&!isborder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                move.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move.y -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                move.x += 1;
            }
        }


        // 归一化方向向量，使得摄像机以相同速度移动，而不考虑对角线移动时的速度增加
        move = move.normalized;

        // 乘以移动速度和时间增量，确保移动与帧率无关
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

