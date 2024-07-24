using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSell : MonoBehaviour
{
    public WallController tower;
    private void OnMouseDown()
    {
        Debug.Log("Mouse clicked sell");
        tower.Sell();
    }
}
