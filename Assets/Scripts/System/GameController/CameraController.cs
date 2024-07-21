using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制摄像机移动速度

    void Update()
    {
        Vector3 move = new Vector3();

        // 检测WASD键输入
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

        // 归一化方向向量，使得摄像机以相同速度移动，而不考虑对角线移动时的速度增加
        move = move.normalized;

        // 乘以移动速度和时间增量，确保移动与帧率无关
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

