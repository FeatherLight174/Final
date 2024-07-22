using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAlpha : MonoBehaviour
{
    private EnemyBeingAttacked enemy;
    private float alphaValue;
    public float fadeTime;
    private SpriteRenderer bar;
    void Start()
    {
        bar = GetComponent<SpriteRenderer>();
        enemy = GetComponentInParent<EnemyBeingAttacked>();
    }

    void Update()
    {
        if (enemy.IsAttacked >= 0)
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
