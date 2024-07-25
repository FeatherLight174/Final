using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallUpgradeText : MonoBehaviour
{
    public WallController tower;
    private int wallLevel;
    private float wallUpgradeCost = 0;
    private float wallSellPrice = 0;
    private float price = 0;
    public HPManagement health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wallLevel = tower.wallLevel;
        if (wallLevel < 3)
        {
            wallUpgradeCost = GameConstant.wallUpgradeCost[wallLevel];
        }
        else
        {
            wallUpgradeCost = 0;
        }
        price = 0;
        for (int i = 0; i < wallLevel; i++)
        {
            price += GameConstant.wallUpgradeCost[i];
        }
        wallSellPrice = (int)(price * health.HP / health.MaxHP * GameConstant.SellFactor);
        if (wallLevel <= 2)
        {
            GetComponent<TextMeshPro>().text = "Upgrade: " + wallUpgradeCost.ToString() + " gold\n\nSell: " + wallSellPrice.ToString() + " gold\n" + "ÑªÁ¿:" + health.HP + "/" + health.MaxHP;
        }
        else if(wallLevel == 3)
        {
            GetComponent<TextMeshPro>().text = "Max level reached\n\nSell: " + wallSellPrice.ToString() + " gold\n" + "ÑªÁ¿:" + health.HP + "/" + health.MaxHP; ;
        }
    }
}
