using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUpgrade : MonoBehaviour
{
    public WallController tower;
    private void Update()
    {
        if (tower.wallLevel >= Base.level)
        {
            tower.wallLevel = Base.level;
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else if (GameConstant.wallUpgradeCost[tower.wallLevel] > GoldAndElectricity.gold)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse clicked upgrade");
        if (tower.wallLevel < Base.level)
        {
            tower.Upgrade();
        }
    }
}
