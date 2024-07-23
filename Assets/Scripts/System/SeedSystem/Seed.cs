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
    public GameObject QuickTower;
    public GameObject Cammo;
    private float PriceTower = GameConstant.PriceTower;
    private float PricePower = GameConstant.PricePower;
    private float PriceGold = GameConstant.PriceGold;
    private float PriceShield = GameConstant.PriceShield;
    private float PriceQuickTower = GameConstant.PriceQuickTower;
    private float PriceCammo = GameConstant.PriceCammo;
    public static bool goldIsFree = false;
    public static bool towerIsFree = false;
    private bool day2GoldCanBeFree = true;
    private bool day2TowerCanBeFree = true;
    private bool day3GoldCanBeFree = true;
    private bool day3TowerCanBeFree = true;

    private int enemy = 0;
    private GameObject Placed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Clock.Day == 2)
        {
            if (day2GoldCanBeFree)
            {
                goldIsFree = true;
                day2GoldCanBeFree = false;
            }
            if (day2TowerCanBeFree)
            {
                towerIsFree = true;
                day2TowerCanBeFree = false;
            }
        }
        if (Clock.Day == 3)
        {
            if (day3GoldCanBeFree)
            {
                goldIsFree = true;
                day3GoldCanBeFree = false;
            }
            if (day3TowerCanBeFree)
            {
                towerIsFree = true;
                day3TowerCanBeFree = false;
            }
        }

        PriceTower = GameConstant.PriceTower;
        PricePower = GameConstant.PricePower;
        PriceGold = GameConstant.PriceGold;
        PriceShield = GameConstant.PriceShield;
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

    
    private void OnMouseDown()
    {
        // 当鼠标点击触发器时执行此方法
        //Debug.Log("Clicked on object: ");
        if (m_IsActive)
        {
            if (MouseController.NowMouse == mouseState.Gold)
            {
                if (goldIsFree)
                {
                    GameConstant.PriceGold += 10;
                    Placed = Instantiate(Gold, transform.position, Quaternion.identity);
                    m_IsActive = false;
                    goldIsFree = false;
                }
                else if (GoldAndElectricity.gold >= PriceGold)
                {
                  
                    GoldAndElectricity.gold -= PriceGold;
                    
                    GameConstant.PriceGold += 10; 
                    Placed = Instantiate(Gold, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Tower)
            {
                if (towerIsFree)
                {
                    Placed = Instantiate(Tower, transform.position, Quaternion.identity);
                    m_IsActive = false;
                    towerIsFree = false;
                }
                else if (GoldAndElectricity.gold >= PriceTower)
                {
                    GoldAndElectricity.gold -= PriceTower;
                    Placed = Instantiate(Tower, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Power)
            {

                if (GoldAndElectricity.gold >= PricePower)
                {
                    GoldAndElectricity.gold -= PricePower;
                    Placed = Instantiate(Power, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Shield)
            {
                if (GoldAndElectricity.gold >= PriceShield)
                {
                    GoldAndElectricity.gold -= PriceShield;
                    Placed = Instantiate(Shield, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }

            else if(MouseController.NowMouse == mouseState.TowerQuick)
            {
                if(GoldAndElectricity.gold >= PriceQuickTower)
                {
                    GoldAndElectricity.gold -= PriceQuickTower;
                    Placed = Instantiate(QuickTower, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse= mouseState.None;
            }
            else if (MouseController.NowMouse == mouseState.Cammo)
            {
                if (GoldAndElectricity.gold >= PriceCammo)
                {
                    GoldAndElectricity.gold -= PriceCammo;
                    Placed = Instantiate(Cammo, transform.position, Quaternion.identity);
                    m_IsActive = false;
                }
                MouseController.NowMouse = mouseState.None;
            }
        }
        
    }    // 调用其他方法处理点击事件，例如改变物体颜色
        
}
