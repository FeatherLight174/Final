using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupObject;

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 如果是2D弹窗，确保Z轴位置为0

            // 如果点击在弹窗物体上，直接返回
            Collider2D popupCollider = popupObject.GetComponent<Collider2D>();
            if (popupCollider != null && popupCollider.OverlapPoint(mousePosition))
                return;

           
            popupObject.SetActive(false);
        }
    }
}
