using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public TowerController tower;
    private void Update()
    {
        if (tower.towerLevel >= Base.level || GameConstant.towerUpgradeCost[tower.towerIndex, tower.towerLevel] > GoldAndElectricity.gold)
        {
            tower.towerLevel = Base.level;
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
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
