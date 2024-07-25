using UnityEngine;

public class CameraController : MonoBehaviour
{
    private  float moveSpeed = 10f; // ����������ƶ��ٶ�
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




        // ���WASD������
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


        // ��һ������������ʹ�����������ͬ�ٶ��ƶ����������ǶԽ����ƶ�ʱ���ٶ�����
        move = move.normalized;

        // �����ƶ��ٶȺ�ʱ��������ȷ���ƶ���֡���޹�
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

