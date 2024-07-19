using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MouseState;

public class Seed : MonoBehaviour
{
    private bool m_IsActive = false;
    public GameObject Gold;
    public GameObject Tower;
    public GameObject Power;
    public GameObject Shield;
    public float PriceTower;
    public float PricePower;
    public float PriceGold;
    public float PriceShield;
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
        if (MouseController.NowMouse == mouseState.Gold)
        {
            if (GoldAndElectricity.gold >= PriceGold)
            {
                Instantiate(Gold, transform.position, Quaternion.identity);
            }
            MouseController.NowMouse = mouseState.None;
        }
        else if(MouseController.NowMouse == mouseState.Tower)
        {
            Instantiate(Tower, transform.position, Quaternion.identity);
            MouseController.NowMouse = mouseState.None;
        }
        else if(MouseController.NowMouse == mouseState.Power)
        {
            Instantiate(Power, transform.position, Quaternion.identity);
            MouseController.NowMouse = mouseState.None;
        }
        else if(MouseController.NowMouse == mouseState.Shield)
        {
            Instantiate(Gold, transform.position, Quaternion.identity);
            MouseController.NowMouse = mouseState.None;
        }


    }    // 调用其他方法处理点击事件，例如改变物体颜色
        
}
