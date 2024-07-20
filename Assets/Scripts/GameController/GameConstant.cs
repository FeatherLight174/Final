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
    public static float GoldLevel2 = 200;
    public static float GoldLevel3 = 450;

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


    //Bullet
    public static float BulletAttack = 10;

}
