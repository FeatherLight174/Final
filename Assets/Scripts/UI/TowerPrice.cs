using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPrice : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Seed.towerIsFree)
        {
            tmpText.text = "����: Free!";
        }
        else
        {
            tmpText.text = "����: " + GameConstant.PriceTower;
        }
       
    }
}
