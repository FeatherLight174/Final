using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MouseState;

public class Seed : MonoBehaviour
{
    private bool m_IsActive = true;
    public GameObject Gold;
    public GameObject Tower;
    public GameObject Power;
    public GameObject Shield;
    public float PriceTower = GameConstant.PriceTower;
    public float PricePower = GameConstant.PricePower;
    public float PriceGold = GameConstant.PriceGold;
    public float PriceShield = GameConstant.PriceShield;

    private int enemy = 0;
    private GameObject Placed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy > 0)
        {
            m_IsActive = false;
        }
        else if(enemy <= 0)
        {
            m_IsActive=true;
            enemy = 0;
        }
        if (Placed == null)
        {
            m_IsActive = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy += 1;
            Debug.Log("Enter");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy -= 1;
            Debug.Log("Exit");
        }
    }
    private void OnMouseDown()
    {
        // 当鼠标点击触发器时执行此方法
        Debug.Log("Clicked on object: ");
        if (m_IsActive)
        {
            if (MouseController.NowMouse == mouseState.Gold)
            {
                if (GoldAndElectricity.gold >= PriceGold)
                {
                    Debug.Log("sssssssssssss");
                    Placed = Instantiate(Gold, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Tower)
            {
                if (GoldAndElectricity.gold >= PriceTower)
                {
                    Placed = Instantiate(Tower, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Power)
            {
                if (GoldAndElectricity.gold >= PricePower)
                {
                    Placed = Instantiate(Power, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Shield)
            {
                if (GoldAndElectricity.gold <= PriceShield)
                {
                    Placed = Instantiate(Shield, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
        }
        
    }    // 调用其他方法处理点击事件，例如改变物体颜色
        
}
