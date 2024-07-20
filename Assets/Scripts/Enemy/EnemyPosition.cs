using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    public GameObject parent;
    public GameObject sprite;
    void Update()
    {
        parent.transform.position += sprite.transform.localPosition;
        sprite.transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + 0.6f, parent.transform.position.z);
    }
}
