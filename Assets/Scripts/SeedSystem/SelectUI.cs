using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MouseState;

public class SelectUI : MonoBehaviour
{
    public GameObject Gold;
    public GameObject Power;
    public GameObject Tower;
    public GameObject Shield;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoldEvent()
    {
        MouseController.NowMouse = mouseState.Gold;
        Debug.Log("gold");
    }

    public void PowerEvent()
    {
        MouseController.NowMouse = mouseState.Power;
    }

    public void TowerEvent()
    {
        MouseController.NowMouse =mouseState.Tower;
    }

    public void ShieldEvent()
    {
        MouseController.NowMouse=mouseState.Shield;
    }
}
