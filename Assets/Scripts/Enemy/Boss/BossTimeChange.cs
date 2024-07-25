using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossTimeChange : MonoBehaviour
{
    public Animator animator;
    private float m_Timer;
    private float m_DamageTimer;
    public bool Victory;
    public float CD;
    public float DamageBefore;
    public GameObject[] enemies;
    private GameObject knight;
    public GameObject[] buildings;

    bool foundTower = false;
    bool foundTrue = false;
    public GameObject targetSprite;
    public GameObject targetObject;

    public float skillDamage;

    private Vector3[] buildingToSelf;

    public float range;
    private bool[] buildingWithinRange;
    private float[] distanceBuilding;
    int minValidTowerDistanceIndex = 0;
    public float SkillPost;
    public bool m_isInSkilled = false;
    public float SkillCoolDown;
    private float m_skillTimer = 0;
    private bool m_isSkilled = false;

    private bool m_isLocked = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_skillTimer += Time.deltaTime;
        /*enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].transform.Find("Range").gameObject.CompareTag("Knight"))
            {
                knight = enemies[i].transform.Find("Range").gameObject;
            }
        }
        if (knight.GetComponent<ability>().IsIntensify)
        {
            m_Timer = 0;
            TimeChange(0);
        }*/
        buildings = GameObject.FindGameObjectsWithTag("Building");

        buildingToSelf = new Vector3[(int)buildings.Length]; 
        buildingWithinRange = new bool[(int)buildings.Length];
        distanceBuilding = new float[(int)buildings.Length];
        for (int i = 0; i < buildings.Length; i++)
        {
            // 塔到自身向量
            buildingToSelf[i] = transform.position - buildings[i].transform.position;
            // 检测塔是否在范围内
            if (buildingToSelf[i].magnitude <= range)
            {
                buildingWithinRange[i] = true;
                // 记录敌人与基地距离
                distanceBuilding[i] = buildingToSelf[i].magnitude;
            }
            else
            {
                buildingWithinRange[i] = false;
                // 记录敌人与基地距离为极大值（无效）
                distanceBuilding[i] = Mathf.Infinity;
            }
        }
        // 防止默认索0号塔
        // 每个敌人以“打擂台”判断最接近基地
        foundTower = false;
        minValidTowerDistanceIndex = 0;
        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildingWithinRange[i] == true)
            {
                foundTower = true;
            }
            if (distanceBuilding[i] < distanceBuilding[minValidTowerDistanceIndex] && buildingWithinRange[i] == true)
            {
                minValidTowerDistanceIndex = i;
            }
        }
        if (!foundTower && m_DamageTimer > 0)
        {
            if (m_DamageTimer < DamageBefore + SkillPost)
            {
                animator.SetBool("Skill", true);
                m_DamageTimer += Time.deltaTime;
            }
            else
            {
                m_DamageTimer = 0;
                m_DamageTimer = 0;
                m_isInSkilled = false;
                m_skillTimer = 0;
                m_isSkilled = false;
                animator.SetBool("Skill", false);
                m_isLocked = false;
                Destroy(targetObject);
            }
        }
        if (!Clock.IsNight)
        {
            Destroy(targetObject);
            m_DamageTimer = 0;
            m_isInSkilled = false;
            m_skillTimer = 0;
            animator.SetBool("Skill", false);
        }
        if (foundTower && Clock.IsNight && m_skillTimer >= SkillCoolDown)
        {
            animator.SetBool("Skill",true);
            if (!m_isLocked)
            {
                targetObject = Instantiate(targetSprite, transform.position - buildingToSelf[minValidTowerDistanceIndex], Quaternion.identity);
                m_isLocked = true;
            }
            Debug.Log(000000000000);
            m_isInSkilled = true;
            m_DamageTimer += Time.deltaTime;
            
            if (m_DamageTimer > DamageBefore)
            {
                if (!m_isSkilled)
                {
                    DamageTower(skillDamage);
                    m_isSkilled = true;
                }

                Destroy(targetObject);
                if(m_DamageTimer > DamageBefore + SkillPost)
                {
                    m_DamageTimer = 0;
                    m_isInSkilled = false;
                    m_skillTimer = 0;
                    m_isSkilled = false;
                    animator.SetBool("Skill", false);
                    m_isLocked = false;
                }
                
            }
            
            
        }
            m_Timer += Time.deltaTime;
        if (m_Timer > CD)
        {
            m_Timer = 0;
            TimeChange(0);
        }
        if (m_Timer > 0 && m_Timer < 1.75)
        {
            Victory = true;
            animator.SetBool("Victory", true);

        }
        else
        {
            Victory = false;
            animator.SetBool("Victory", false);
        }
    }

    void TimeChange(int hour)
    {
        Clock.DayTime = 0;
        Clock.NowHour = hour;
    }
    void DamageTower(float damage)
    {

        buildings[minValidTowerDistanceIndex].GetComponent<HPManagement>().TakeDamage(damage);
    }
}
