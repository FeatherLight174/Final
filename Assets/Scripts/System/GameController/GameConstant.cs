using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant
{

    public static float SellFactor = 0.75f;

    public static float PriceTower = 10;
    public static float PriceShield  = 10;

    //时间系统
    //包含了一天是多长时间，在这一天当中的小时
    public static float DayTime = 360;
    public static float HourTime = 5;
    public static float AttackFactorNight = 1.5f;
    public static float SpeedFactorNight = 0.75f;
 
    //Home
    public static float[] HomeGoldProduce = new float[3] { 2, 3, 4 }; 
    public static float[] HomeGoldProduceCD = new float[3] { 5,5,3 };
    public static float[] HomePowerProduce = new float[3] {0,0,5};
    public static float[] HomePowerProduceCD = new float[3] { 2,2,10 };
    public static float[] HomeHP = new float[3] { 1000,2000,4000};
    public static float Homelevel2 = 500;
    public static float Homelevel3 = 2000;



    //Gold
    public static float[] HPGold = new float[3] { 100,150,200};
    public static float PriceGold = 10;
    public static float[] GoldCD = new float[3] { 5, 4, 2 };
    public static float[] GoldLevelProduce = new float[3] { 4, 5, 5 };
    public static float GoldLevel2 = 100;
    public static float GoldLevel3 = 250;

    //Power
    public static float HPPower = 500;
    public static float PricePower = 750;
    public static float PowerCD = 10;
    public static float PowerProduce = 15;


    public static float HPTower = 100;

    public static float HPShield = 750;

    //源石虫
    //记录了敌人的血量，速度因数，普通敌人人的攻击力，攻击间隔
    public static float HPEnemy = 200;
    public static float vFactor = 1.0f;
    public static float EnemyAttack = 10;
    public static float EnemyMovespeed = 2f;
    public static float AttackCD = 1f;

    // 破阵者
    public static float HPEnemy2 = 120;
    public static float vFactor2 = 1.0f;
    public static float EnemyAttack2 = 20;
    public static float EnemyMovespeed2 = 4f;
    public static float AttackCD2 = 0.5f;
    // Towers
    // 注意改new float[行, 列]的行、列值
    /* 塔编号目录
     * new float[塔编号, 等级(0开始)]
     * 0. 测试塔（之后得改的！）
     * 1. ？
    */
    public static float[,] towerHealth = new float[2, 3]
    {{100f, 150f, 250f}, {1f, 2f, 3f}};
    public static float[,] towerRange = new float[2, 3]
    {{4f, 5f, 6f}, {1f, 2f, 3f}};
    public static float[,] towerShootSpeed = new float[2, 3]
    {{2f, 2.25f, 2.5f}, {1f, 2f ,3f}};
    public static float[,] towerRotateSpeed = new float[2, 3]
    {{90f, 105f, 120f}, {1f, 2f, 3f}};
    public static float[,] towerDamage = new float[2, 3]
    {{10f, 12f, 15f}, {1f, 2f, 3f}};
    public static float[,] towerBulletSpeed = new float[2, 3]
    {{8f, 9f, 10f}, {1f, 2f, 3f}};
    public static float[,] towerPowerConsumption = new float[2, 3]
    {{0f, 0f, 0f}, {1f, 2f, 3f}};
    public static float[,] towerUpgradeCost = new float[2, 3]
    {{10f, 10f, 20f}, {1f, 2f, 3f}};

    //Bullet
    //普通子弹
    public static float BulletAttack = 10;

}
