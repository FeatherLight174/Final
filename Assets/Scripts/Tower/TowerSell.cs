using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSell : MonoBehaviour
{
    public TowerController tower;
    private void OnMouseDown()
    {
        tower.Sell();
    }
}
