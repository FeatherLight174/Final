using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public TowerController tower;
    private void OnMouseDown()
    {
        tower.Upgrade();
    }
}
