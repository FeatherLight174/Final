using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public TowerController tower;
    private void Update()
    {
        if (tower.towerLevel >= 3)
        {
            tower.towerLevel = 3;
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }
    private void OnMouseDown()
    {
        if (tower.towerLevel <= 2)
        {
            tower.Upgrade();
        }
    }
}
