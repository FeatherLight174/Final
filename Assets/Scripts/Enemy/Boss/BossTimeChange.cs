using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimeChange : MonoBehaviour
{
    private float m_Timer;
    private float m_DamageTimer;
    public float CD;
    public float DamageBefore;
    public GameObject[] enemies;
    private GameObject knight;
    public GameObject[] buildings;

    public GameObject targetSprite;
    public GameObject targetObject;

    public float skillDamage;

    private Vector3[] buildingToSelf;

    public float range;
    private bool[] buildingWithinRange;
    private float[] distanceBuilding;
    int minValidTowerDistanceIndex = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].transform.Find("Range") != null)
            {
                if (enemies[i].transform.Find("Range").gameObject.CompareTag("Knight"))
                {
                    knight = enemies[i].transform.Find("Range").gameObject;
                }
            }
        }
        if (knight.GetComponent<ability>().IsIntensify)
        {
            m_Timer = 0;
            TimeChange(0);
        }
        buildings = GameObject.FindGameObjectsWithTag("Building");

        for (int i = 0; i < buildings.Length; i++)
        {
            // ������������
            Debug.Log(i);
            buildingToSelf[i] = transform.position - buildings[i].transform.position;
            // ������Ƿ��ڷ�Χ��
            if (buildingToSelf[i].magnitude <= range)
            {
                buildingWithinRange[i] = true;
                // ��¼��������ؾ���
                distanceBuilding[i] = buildingToSelf[i].magnitude;
            }
            else
            {
                buildingWithinRange[i] = false;
                // ��¼��������ؾ���Ϊ����ֵ����Ч��
                distanceBuilding[i] = Mathf.Infinity;
            }
        }
        // ��ֹĬ����0����
        bool foundTower = false;
        minValidTowerDistanceIndex = 0;
        // ÿ�������ԡ�����̨���ж���ӽ�����
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
        if (foundTower && Clock.IsNight)
        {
            m_DamageTimer += Time.deltaTime;
            targetObject = Instantiate(targetSprite);
            if (m_DamageTimer > DamageBefore || !Clock.IsNight)
            {
                Destroy(targetObject);
                m_DamageTimer = 0;
                DamageTower(skillDamage);
            }
            
        }
            m_Timer += Time.deltaTime;
        if (m_Timer > CD)
        {
            m_Timer = 0;
            TimeChange(0);
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
