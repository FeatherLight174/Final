using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // ����������ƶ��ٶ�

    void Update()
    {
        Vector3 move = new Vector3();

        // ���WASD������
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

        // ��һ������������ʹ�����������ͬ�ٶ��ƶ����������ǶԽ����ƶ�ʱ���ٶ�����
        move = move.normalized;

        // �����ƶ��ٶȺ�ʱ��������ȷ���ƶ���֡���޹�
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

