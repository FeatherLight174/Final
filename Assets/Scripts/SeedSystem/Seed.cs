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
    public float PriceTower;
    public float PricePower;
    public float PriceGold;
    public float PriceShield;

    private GameObject Placed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(Placed == null)
        {
            m_IsActive = true;
        }

    }    // 调用其他方法处理点击事件，例如改变物体颜色
        
}
