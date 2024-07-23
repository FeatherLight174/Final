using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseUpgradeText : MonoBehaviour
{
    public Base tower;
    private int Level;
    private float UpgradeCost = 0;
    public HPManagement health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level = Base.level;
        if (Level == 1)
        {
            UpgradeCost = GameConstant.Homelevel2;
        }
        else if (Level == 2)
        {
            UpgradeCost = GameConstant.Homelevel3;
        }
        else
        {
            UpgradeCost = 0;
        }
        if (UpgradeCost > 0)
        {
            GetComponent<TextMeshPro>().text = "Upgrade: " + UpgradeCost.ToString() + " gold\n\nMax building level: " + Level.ToString();
        } 
        else
        {
            GetComponent<TextMeshPro>().text = "Max level reached\n\n";
        }
    }
}
