using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Panel
    public GameObject sellPanel;

    // Cost
    private float generatorCost = GameConstant.PricePower;
    private float sellRate = GameConstant.SellFactor;

    // Basic function
    private float generatingCD = GameConstant.PowerCD;
    private float electricityPerTime = GameConstant.PowerProduce;
    private float m_Timer;
    private int clock;
    private Animator animator;

    // HP
    private float fullHP = GameConstant.HPPower;
    public float currentHP;

    private HPManagement Hp;

    // Panel flag
    private int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Hp = gameObject.GetComponent<HPManagement>();
        m_Timer = 0;
        currentHP = fullHP;
        Hp.SetHP(GameConstant.HPPower);
    }

    private void OnMouseDown()
    {
        /*if (flag % 2 == 0)
        {
            sellPanel.SetActive(true);
            //feature.SetActive(true);
        }
        else if (flag % 2 == 1)
        {
            sellPanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag++;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (clock != Clock.NowHour)
        {
            clock = Clock.NowHour;
            if ((clock >= 8) && (clock <= 18))
            {
                GoldAndElectricity.electricity += electricityPerTime;
                animator.SetBool("IsWorking", true);
            }
            else
            {
                animator.SetBool("IsWorking", false);
            }
        }
        if ((!sellPanel.activeSelf))
        {
            flag = 0;
        }
    }

    public void Sell()
    {
        GoldAndElectricity.gold += (int)(((Hp.HP / Hp.MaxHP) * generatorCost) * sellRate);
        Destroy(gameObject);
    }
}