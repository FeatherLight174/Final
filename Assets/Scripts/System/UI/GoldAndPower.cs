using UnityEngine;
using UnityEngine.UI;

public class GoldAndPower : MonoBehaviour
{
    public Text textComponent;


    void Update()
    {
        
    textComponent.text = "Gold " + GoldAndElectricity.gold + "\n"+"Power" + GoldAndElectricity.electricity;
            

           
    }
}
