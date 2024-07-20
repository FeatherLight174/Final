using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant
{

    public static float SellFactor = 0.75f;

    public static float PriceTower = 10;
    public static float PriceShield  = 10;

 
    //Home
    public static float[] HomeGoldProduce = new float[3] { 2, 4, 6 }; 
    public static float[] HomeGoldProduceCD = new float[3] { 1,1,1 };
    public static float[] HomePowerProduce = new float[3] {10,20,30};
    public static float[] HomePowerProduceCD = new float[3] { 2,2,2 };
    public static float[] HomeHP = new float[3] { 1000,2000,3000};
    public static float Homelevel2 = 1000;
    public static float Homelevel3 = 1500;



    //Gold
    public static float[] HPGold = new float[3] { 100,150,200};
    public static float PriceGold = 10;
    public static float[] GoldCD = new float[3] { 1, 1, 1 };
    public static float[] GoldLevelProduce = new float[3] { 1, 2, 3 };
    public static float GoldLevel2 = 20;
    public static float GoldLevel3 = 40;

    //Power
    public static float HPPower = 150;
    public static float PricePower = 10;
    public static float PowerCD = 1;
    public static float PowerProduce = 15;


    public static float HPTower = 100;

    public static float HPShield = 750;

    //Enemy
    public static float HPEnemy = 200;
    public static float vFactor = 1.0f;
    public static float EnemyAttack = 10;
    public static float EnemyMovespeed = 0.1f;
    public static float AttackCD = 0.5f;

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
    public static float BulletAttack = 10;

}
