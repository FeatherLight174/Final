using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAndElectricity : MonoBehaviour
{   
    public static float gold;
    public static float electricity;

    // Start is called before the first frame update
    void Start()
    {
        gold = 100;
        electricity = 100;
        Debug.Log(gold);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
