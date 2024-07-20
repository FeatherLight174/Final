using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupObject;

    void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ��ȡ�����λ��
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // �����2D������ȷ��Z��λ��Ϊ0

            // �������ڵ��������ϣ�ֱ�ӷ���
            Collider2D popupCollider = popupObject.GetComponent<Collider2D>();
            if (popupCollider != null && popupCollider.OverlapPoint(mousePosition))
                return;

           
            popupObject.SetActive(false);
        }
    }
}
