using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldAndPower : MonoBehaviour
{
    public TextMeshProUGUI tmpText;


    void Update()
    {
        
    tmpText.text = "���: " + GoldAndElectricity.gold + "\n"+"����: " + GoldAndElectricity.electricity + "\n" + "��"
             + Clock.Day + "���" +  + Clock.NowHour+"ʱ";
            

           
    }
}
