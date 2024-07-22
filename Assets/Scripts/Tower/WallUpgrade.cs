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
    }
    private void OnMouseDown()
    {
        if (tower.wallLevel < Base.level)
        {
            tower.Upgrade();
        }
    }
}
