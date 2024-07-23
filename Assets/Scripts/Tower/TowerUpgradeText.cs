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
        towerUpgradeCost = GameConstant.towerUpgradeCost[tower.towerIndex, towerLevel];
        price = 0;
        for (int i = 0; i < towerLevel; i++)
        {
            price += GameConstant.towerUpgradeCost[tower.towerIndex, i];
        }
        towerSellPrice = (int)(price * health.HP / health.MaxHP * GameConstant.SellFactor);
        GetComponent<TextMeshPro>().text = "Upgrade: " + towerUpgradeCost.ToString() + " gold\n\nSell: " + towerSellPrice.ToString() + " gold";
    }
}
