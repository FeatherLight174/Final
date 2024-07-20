using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Path1 scriptPath1;
    private SpriteRenderer valueBar;
    private float maxHP;
    private float currentHP;
    void Start()
    {
        valueBar = GetComponent<SpriteRenderer>();
        maxHP = GameConstant.HPEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = Path1.GetHP();
        transform.localScale = new Vector3(0.9f * currentHP / maxHP, 0.6f, 1f);
        transform.localPosition = new Vector3(-0.45f * (1 - currentHP / maxHP), 0f, -0.4f);
    }
}
