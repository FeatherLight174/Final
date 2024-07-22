using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthBar : MonoBehaviour
{
    private SpriteRenderer valueBar;
    private HPManagement healthScript;
    private TowerBeingAttacked tower;
    private float maxHP;
    private float currentHP;
    private float alphaValue;
    public float fadeTime;
    void Start()
    {
        valueBar = GetComponent<SpriteRenderer>();
        healthScript = GetComponentInParent<HPManagement>();
        tower = GetComponentInParent<TowerBeingAttacked>();
    }
    void Update()
    {
        maxHP = healthScript.MaxHP;
        if (tower.IsAttacked >= 0)
        {
            alphaValue = 1f;
        }
        else
        {
            alphaValue = Mathf.Max(alphaValue - Time.deltaTime * fadeTime, 0f);
        }
        currentHP = healthScript.HP;
        transform.localScale = new Vector3(0.95f * currentHP / maxHP, 0.16f, 1f);
        transform.localPosition = new Vector3(-0.475f * (1 - currentHP / maxHP), 0.4f, -0.5f);
        valueBar.color = new Color(Mathf.Min(2f * (1f - currentHP / maxHP), 1f), 0.75f * Mathf.Min(1.5f * currentHP / maxHP, 1f), 0f, alphaValue);
    }
}
