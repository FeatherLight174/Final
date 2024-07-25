using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUpgradeText : MonoBehaviour
{
    public Goldmine tower;
    private int Level;
    private float UpgradeCost = 0;
    private float SellPrice = 0;
    private float price = 0;
    public HPManagement health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level = tower.level;
        if (Level == 1)
        {
            UpgradeCost = GameConstant.GoldLevel2;
            price = GameConstant.PriceGold;
        }
        else if (Level == 2)
        {
            UpgradeCost = GameConstant.GoldLevel3;
            price = GameConstant.PriceGold + GameConstant.GoldLevel2;
        }
        else
        {
            UpgradeCost = 0;
            price = GameConstant.PriceGold + GameConstant.GoldLevel2 + GameConstant.GoldLevel3;
        }
        SellPrice = (int)(price * health.HP / health.MaxHP * GameConstant.SellFactor);
        if (Level ==  1)
        {
            GetComponent<TextMeshPro>().text = "Upgrade: " + UpgradeCost.ToString() + " gold\n\nSell: " + SellPrice.ToString() + " gold" + "Ч��:" + "6"+"���/Сʱ" + "����:" + health.HP + "/" + health.MaxHP;
        } 
        else if(Level == 2)
        {
            GetComponent<TextMeshPro>().text = "Upgrade: " + UpgradeCost.ToString() + " gold\n\nSell: " + SellPrice.ToString() + " gold" + "Ч��:" + "11.25" + "���/Сʱ" + "����:" + health.HP + "/" + health.MaxHP;
        }
        else
        {
            GetComponent<TextMeshPro>().text = "Max level reached\n\nSell: " + SellPrice.ToString() + " gold" + "Ч��:" +  "25"+ "���/Сʱ" + "����:" + health.HP + "/" + health.MaxHP;
        }
    }
}
