using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUpgradeText : MonoBehaviour
{
    public TowerController tower;
    private int towerLevel;
    private float towerUpgradeCost = 0;
    private float towerSellPrice = 0;
    private float price = 0;
    public HPManagement health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        towerLevel = tower.towerLevel;
        if (towerLevel < 3)
        {
            towerUpgradeCost = GameConstant.towerUpgradeCost[tower.towerIndex, towerLevel];
        }
        else
        {
            towerUpgradeCost = 0;
        }
        price = 0;
        for (int i = 0; i < towerLevel; i++)
        {
            price += GameConstant.towerUpgradeCost[tower.towerIndex, i];
        }
        towerSellPrice = (int)(price * health.HP / health.MaxHP * GameConstant.SellFactor);
        if (towerLevel == 1)
        {
            GetComponent<TextMeshPro>().text = "Upgrade: " + towerUpgradeCost.ToString() + " gold\nSell: " + towerSellPrice.ToString() + " gold\n" + "攻击力:" + GameConstant.towerDamage[tower.towerIndex,towerLevel -1].ToString() + "\n"+"攻速:"+ GameConstant.towerShootSpeed[tower.towerIndex, towerLevel - 1].ToString() + "发/秒\n总血量:" + GameConstant.towerHealth[tower.towerIndex, towerLevel - 1].ToString()+ "耗电量:" + GameConstant.towerPowerConsumption[tower.towerIndex,towerLevel - 1];
        }
        else if(towerLevel == 2)
        {
            GetComponent<TextMeshPro>().text = "Upgrade: " + towerUpgradeCost.ToString() + " gold\nSell: " + towerSellPrice.ToString() + " gold\n" + "攻击力:" + GameConstant.towerDamage[tower.towerIndex, towerLevel - 1].ToString() + "\n" + "攻速:" + GameConstant.towerShootSpeed[tower.towerIndex, towerLevel - 1].ToString() + "发/秒\n总血量:" + GameConstant.towerHealth[tower.towerIndex, towerLevel - 1].ToString() + "耗电量:" + GameConstant.towerPowerConsumption[tower.towerIndex, towerLevel - 1];
        }
      
        else if(towerLevel == 3)
        {
            GetComponent<TextMeshPro>().text = "Max level reach\nSell: " + towerSellPrice.ToString() + "gold\n" + "攻击力:" + GameConstant.towerDamage[tower.towerIndex, towerLevel - 1].ToString() + "\n" + "攻速:" + GameConstant.towerShootSpeed[tower.towerIndex, towerLevel - 1].ToString() + "发/秒\n总血量:" + GameConstant.towerHealth[tower.towerIndex, towerLevel - 1].ToString() + "耗电量:" + GameConstant.towerPowerConsumption[tower.towerIndex, towerLevel - 1];
        }
      
    }
}
