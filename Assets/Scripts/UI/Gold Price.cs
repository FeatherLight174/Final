using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPrice : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Seed.goldIsFree)
        {
            tmpText.text = "Goldmine: Free!" ;
        }
        else
        {
            tmpText.text = "Goldmine: " + GameConstant.PriceGold;
        }
        
        
    }
}
