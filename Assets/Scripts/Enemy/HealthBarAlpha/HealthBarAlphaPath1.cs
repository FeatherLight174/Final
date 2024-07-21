using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAlphaPath1 : MonoBehaviour
{
    public Path1 scriptPath1;
    private float alphaValue;
    public float fadeTime;
    private SpriteRenderer bar;
    void Start()
    {
        bar = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (scriptPath1.IsAttacked)
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
