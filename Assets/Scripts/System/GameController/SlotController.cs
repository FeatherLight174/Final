using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MouseState;

public class SlotController : MonoBehaviour
{
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseController.NowMouse != mouseState.None)
        {
            gm.SetActive(true);
            Debug.Log("asdfghj");
        }
        else
        {
            gm.SetActive(false);
        }
    }


}
