using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldAndPower : MonoBehaviour
{
    public TextMeshProUGUI tmpText;


    void Update()
    {
        
    tmpText.text = "Gold " + GoldAndElectricity.gold + "\n"+"Power" + GoldAndElectricity.electricity;
            

           
    }
}
