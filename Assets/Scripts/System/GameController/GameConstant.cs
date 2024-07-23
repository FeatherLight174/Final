using UnityEngine;
public class GameConstant : MonoBehaviour
{

    public static float SellFactor = 0.5f;
    public static float PriceQuickTower = 75;
    public static float PriceTower = 50;
    public static float PriceShield  = 10;

    //时间系统
    //包含了一天是多长时间，在这一天当中的小时
    public static float DayTime = 360;
    public static float HourTime = 15;
    public static float AttackFactorNight = 1.5f;
    public static float SpeedFactorNight = 0.75f;
 
    //Home
    public static float[] HomeGoldProduce = new float[3] { 2, 3, 3 }; 
    public static float[] HomeGoldProduceCD = new float[3] { 2,2,1 };
    public static float[] HomePowerProduce = new float[3] {0,2,3};
    public static float[] HomePowerProduceCD = new float[3] { 2,2,2 };
    public static float[] HomeHP = new float[3] { 1000,2000,4000};
    public static float Homelevel2 = 100;
    public static float Homelevel3 = 250;



    //Gold
    public static float[] HPGold = new float[3] { 100,150,200};
    public static float PriceGold = 30;
    public static float[] GoldCD = new float[3] { 5, 4, 4 };
    public static float[] GoldLevelProduce = new float[3] { 2, 3, 5 };
    public static float GoldLevel2 = 80;
    public static float GoldLevel3 = 300;

    //Power
    public static float HPPower = 500;
    public static float PricePower = 100;
    public static float PowerCD = 1;
    public static float PowerProduce = 10;


    public static float HPTower = 100;

    public static float HPShield = 500;

    //源石虫
    //记录了敌人的血量，速度因数，普通敌人人的攻击力，攻击间隔
    public static float HPEnemy = 100;
    public static float vFactor = 1.0f;
    public static float EnemyAttack = 10;
    public static float EnemyMovespeed = 0.75f;
    public static float AttackPre = 0.1f;
    public static float AttackAfter = 0.9f;
    public static float AttackCD;

    // 破阵者
    public static float HPEnemy2 = 250;
    public static float vFactor2 = 1.0f;
    public static float EnemyAttack2 = 25;
    public static float EnemyMovespeed2 = 2f;
    public static float AttackCD2 = 0.5f;
    public static float EnemyAttack2Pre = 0.2f;
    public static float EnemyAttack2After = 0.3f;

    // 屠夫
    public static float HPEnemy3 = 500;
    public static float vFactor3 = 1.0f;
    public static float EnemyAttack3 = 50;
    public static float EnemyMovespeed3 = 0.5f;
    public static float EnemyAttack3Pre = 2f;
    public static float EnemyAttack3After = 1.8f;
    public static float AttackCD3;

    // Towers
    // 注意改new float[行, 列]的行、列值
    /* 塔编号目录
     * new float[塔编号, 等级(0开始)]
     * 0. 箭塔
     * 1. 快速低伤箭塔
     * 2. 爆破塔
    */
    public static float[,] towerHealth = new float[4, 3]
    {{100f, 150f, 250f}, {100f, 150f, 250f}, {150f, 250f, 400f}, {100f, 150f, 250f}};
    public static float[,] towerRange = new float[4, 3]
    {{4f, 5f, 6f}, {6f, 7.5f, 9f}, {3f, 4f, 5f}, {4f, 5f, 6f}};
    public static float[] towerRangeNightFactor = new float[4]
    {0.75f, 0.75f, 0.75f, 0.9f};
    public static float[,] towerShootSpeed = new float[4, 3]
    {{1f, 1.5f, 2f}, {3f, 4f ,5f}, {0.5f, 0.75f, 1f}, {1f, 1.5f, 2f}};
    public static float[,] towerRotateSpeed = new float[4, 3]
    {{90f, 105f, 120f}, {120f, 135f, 150f}, {75f, 90f, 105f}, {120f, 135f, 150f}};
    public static float[,] towerDamage = new float[4, 3]
    {{10f, 12f, 15f}, {3f, 3.5f, 4f}, {25f, 40f, 60f}, {2f, 2f, 2.5f}};
    public static float[] towerDamageNightFactor = new float[4]
    {1.3f, 1.3f, 1.6f, 1.3f};
    public static float[,] towerBulletSpeed = new float[4, 3]
    {{8f, 9f, 10f}, {10f, 11f, 12f}, {6f, 7f, 8f}, {6f, 7f, 8f}};
    public static float[,] towerPowerConsumption = new float[4, 3]
    {{0f, 0f, 0f}, {0f, 0f, 0f}, {2f, 2f, 2f}, {2f, 2f, 2f}};
    public static float[,] towerUpgradeCost = new float[4, 3]
    {{50f, 60f, 90f}, {75f, 90f, 120f}, {100f, 150f, 200f}, {100f, 150f, 200f}};

    // Wall
    public static float[] wallHealth = new float[3]
    {500f, 1000f, 2000f};
    public static float[] wallRecovery = new float[3]
    {0f, 10f, 30f};
    public static float[] wallPowerConsumption = new float[3]
    {0f, 1f, 2f};
    public static float[] wallUpgradeCost = new float[3]
    {50f, 75f, 100f};

    //  Bullet
    // [塔编号, 塔等级]子弹伤害、速度
    // 子弹的伤害、速度写在了Towers里（上面）
}
