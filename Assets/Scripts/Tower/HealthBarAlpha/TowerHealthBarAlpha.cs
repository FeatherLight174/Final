using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthBarAlpha : MonoBehaviour
{
    private TowerBeingAttacked tower;
    private float alphaValue;
    public float fadeTime;
    private SpriteRenderer bar;
    void Start()
    {
        bar = GetComponent<SpriteRenderer>();
        tower = GetComponentInParent<TowerBeingAttacked>();
    }

    void Update()
    {
        if (tower.IsAttacked >= 0)
        {
            alphaValue = 1f;
        }
        else
        {
            alphaValue = Mathf.Max(alphaValue - Time.deltaTime * fadeTime, 0f);
        }
        bar.color = new Color(1f, 1f, 1f, alphaValue);
    }
}
