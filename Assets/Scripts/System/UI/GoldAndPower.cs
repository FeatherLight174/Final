using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldAndPower : MonoBehaviour
{
    public TextMeshProUGUI tmpText;


    void Update()
    {
        
    tmpText.text = "金币: " + GoldAndElectricity.gold + "\n"+"电力: " + GoldAndElectricity.electricity + "\n" + "第"
             + Clock.Day + "天第" +  + Clock.NowHour+"时";
            

           
    }
}
