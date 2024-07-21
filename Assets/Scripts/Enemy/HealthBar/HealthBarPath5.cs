using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPath5 : MonoBehaviour
{
    public Path5 scriptPath5;
    private SpriteRenderer valueBar;
    private float maxHP;
    private float currentHP;
    private float alphaValue;
    public float fadeTime;
    void Start()
    {
        valueBar = GetComponent<SpriteRenderer>();
        maxHP = GameConstant.HPEnemy2;
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptPath5.IsAttacked)
        {
            alphaValue = 1f;
        }
        else
        {
            alphaValue = Mathf.Max(alphaValue - Time.deltaTime * fadeTime, 0f);
        }
        currentHP = scriptPath5.GetHP();
        transform.localScale = new Vector3(0.95f * currentHP / maxHP, 0.8f, 1f);
        transform.localPosition = new Vector3(-0.475f * (1 - currentHP / maxHP), 0f, -0.4f);
        valueBar.color = new Color(Mathf.Min(2f * (1f - currentHP / maxHP), 1f), 0.75f * Mathf.Min(1.5f * currentHP / maxHP, 1f), 0f, alphaValue);
    }
}
