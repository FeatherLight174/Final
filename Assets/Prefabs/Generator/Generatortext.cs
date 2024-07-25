using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneratorText : MonoBehaviour
{
    public Generator tower;
    private float SellPrice;
    private float price = 80;
    public HPManagement health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponentInParent<HPManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        SellPrice = (int)(price * health.HP / health.MaxHP * GameConstant.SellFactor);
        
        GetComponent<TextMeshPro>().text = "\nSell: " + SellPrice.ToString() + " gold\n" + "效率:" + "5"+ "电量/小时\n" + "生命:" + health.HP + "/" + health.MaxHP;
       
       
    }
}

