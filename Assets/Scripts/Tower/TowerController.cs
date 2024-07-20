using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject rangePanel;
    public GameObject sellPanel;
    private int flag = 0;
    // ����Ѫ��
    public float health;
    // ������Χ
    public float range;
    // �������� (��/��)
    public float shootSpeed;
    // ���ټ�ʱ��
    float shootTimer;
    // ����ת��
    public float rotateSpeed;
    // �����ӵ��ٶȣ����ã�
    // public float bulletSpeed;
    // ���������������ã�
    // public float damage;
    // ���˴洢
    public GameObject[] enemies;
    // ���ش洢
    public GameObject homeOrBase;
    // ���м�������ã�
    // public float enemyIntervalTime;
    // �ӵ���ָ����ص�����
    public Vector3[] enemyToBase;
    // �ӵ���ָ�������Լ���������
    public Vector3[] enemyToTower;
    // �����Ƿ��ڷ�Χ��
    bool[] enemyWithinRange;
    // ��������صľ��루��enemyToBaseȡģ��
    float[] distanceEnemyBase;
    // �����Χ�ڵ��˵����ؾ���ĵ��˱�ţ�0��ʼ��
    int minValidEnemyBaseDistanceIndex = 0;
    // ���ٵĵ��������ڱȽ�ʱ��
    float shootInterval;
    // ������ӵ�
    // �˺������ӵ�������������Ҫѡȡ��ȷ���ӵ�
    public GameObject bullet;
    // ���ʵ����׼������Ӧ��׼����С�����ֵ����ʼ�����ӵ�������ѧ���������⣩
    // ��Ҫ��0��
    // DO NOT PUT "ZERO" HERE��
    public float angleDelta;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �
        shootTimer += Time.deltaTime;
        shootInterval = 1 / shootSpeed;
        // �ҵ����е��ˣ�������enemies��
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // ��ÿ�����˼���
        enemyToBase = new Vector3[enemies.Length];
        enemyToTower = new Vector3[enemies.Length];
        enemyWithinRange = new bool[enemies.Length];
        distanceEnemyBase = new float[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            // ���˵���������
            enemyToBase[i] = homeOrBase.transform.position - enemies[i].transform.position;
            // ���˵�������
            enemyToTower[i] = transform.position - enemies[i].transform.position;
            // �������Ƿ������ڲ�
            if (enemyToTower[i].magnitude <= range)
            {
                enemyWithinRange[i] = true;
                // ��¼��������ؾ���
                distanceEnemyBase[i] = enemyToBase[i].magnitude;
            }
            else
            {
                enemyWithinRange[i] = false;
                // ��¼��������ؾ���Ϊ����ֵ����Ч��
                distanceEnemyBase[i] = Mathf.Infinity;
            }
        }
        // ��ֹĬ��������0�ŵ���
        bool foundEnemy = false;
        minValidEnemyBaseDistanceIndex = 0;
        // ÿ�������ԡ�����̨���ж���ӽ�����
        for (int i = 0;i < enemies.Length;i++)
        {
            if (enemyWithinRange[i] == true)
            {
                foundEnemy = true;
            }
            if (distanceEnemyBase[i] < distanceEnemyBase[minValidEnemyBaseDistanceIndex] && enemyWithinRange[i] == true)
            {
                minValidEnemyBaseDistanceIndex = i;
            }
        }
        // ��������
        if (foundEnemy)
        {
            // �����ת���������ת
            // ��ʱ��
            Vector3 direction = new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180), 0f);
            if (Vector3.Dot(direction, -enemyToTower[minValidEnemyBaseDistanceIndex]) < 0)
            {
                if (Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f < 0)
                {
                    transform.Rotate(0f, 0f, Mathf.Max(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeed), Space.Self);
                }
                else
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, -Time.deltaTime * rotateSpeed), Space.Self);
                }
            }
            else
            {
                // ��ʱ��
                if (Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f > 0)
                {
                    transform.Rotate(0f, 0f, Mathf.Min(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, Time.deltaTime * rotateSpeed), Space.Self);
                }
                // ˳ʱ��
                else
                {
                    transform.Rotate(0f, 0f, Mathf.Max(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f, -Time.deltaTime * rotateSpeed), Space.Self);
                }
            }
        }
        if (foundEnemy && (Mathf.Abs(Mathf.Atan((-Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) + enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x) / (1 + Mathf.Tan(transform.eulerAngles.z / 180f * Mathf.PI) * enemyToTower[minValidEnemyBaseDistanceIndex].y / enemyToTower[minValidEnemyBaseDistanceIndex].x)) / Mathf.PI * 180f) <= angleDelta))
        {
            if (shootTimer >= shootInterval)
            {
                shootTimer = 0;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        Debug.Log("Shoot!");
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.25f), transform.rotation);
    }

    private void OnMouseDown()
    {
        if (flag % 2 == 0)
        {
            sellPanel.SetActive(true);
            rangePanel.SetActive(true);

            //feature.SetActive(true);
        }
        else if (flag % 2 == 1)
        {
            sellPanel.SetActive(false);
            rangePanel.SetActive(false);
            //feature.SetActive(false);
        }
        flag++;
    }
}
