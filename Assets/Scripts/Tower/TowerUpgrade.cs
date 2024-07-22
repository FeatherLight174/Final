using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public TowerController tower;
    private void Update()
    {
        if (tower.towerLevel >= Base.level)
        {
            tower.towerLevel = Base.level;
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }
    private void OnMouseDown()
    {
        if (tower.towerLevel < Base.level)
        {
            tower.Upgrade();
        }
    }
}
