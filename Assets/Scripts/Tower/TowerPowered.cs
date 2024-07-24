using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPowered : MonoBehaviour
{
    public TowerController tower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tower.powerConsumption > 0)
        {
            gameObject.SetActive(true);
            if (tower.powerGet == 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            }
            else if (tower.powerGet > 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
            }
        }
        else if (tower.powerConsumption == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);
        }
    }
}
