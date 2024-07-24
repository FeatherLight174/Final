using UnityEngine;

public class CameraController : MonoBehaviour
{
    private  float moveSpeed = 10f; // ����������ƶ��ٶ�
    private bool enable = false;
    void Update()
    {
        Vector3 move = new Vector3();

        // ���WASD������
        if((Clock.Day >=3)&&(Clock.NowHour >= 6))
        {
            enable = true;
        }
        if (enable)
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

