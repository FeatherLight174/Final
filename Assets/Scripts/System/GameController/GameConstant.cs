using UnityEngine;
public class GameConstant : MonoBehaviour
{

    public static float SellFactor = 0.6f;
    public static float PriceQuickTower = 70;
    public static float PriceTower = 45;
    public static float PriceShield  = 30;
    public static float FreezeTime = 3;

    //时间系统
    //包含了一天是多长时间，在这一天当中的小时
    public static float DayTime = 360;
    public static float HourTime = 15;
    public static float AttackFactorNight = 1.5f;
    public static float SpeedFactorNight = 0.75f;
 
    //Home
    public static float[] HomeGoldProduce = new float[3] { 1, 2, 3 }; 
    public static float[] HomeGoldProduceCD = new float[3] { 1,1,1 };
    public static float[] HomePowerProduce = new float[3] {0,1,2};
    public static float[] HomePowerProduceCD = new float[3] { 15,15,15 };
    public static float[] HomeHP = new float[3] { 1000,2000,4000};
    public static float Homelevel2 = 100;
    public static float Homelevel3 = 250;



    //Gold
    public static float[] HPGold = new float[3] { 100,150,200};
    public static float PriceGold = 25;
    public static float[] GoldCD = new float[3] { 5, 4, 4 };
    public static float[] GoldLevelProduce = new float[3] { 2, 3, 5 };
    public static float GoldLevel2 = 70;
    public static float GoldLevel3 = 300;

    //Power
    public static float HPPower = 500;
    public static float PricePower = 80;
    public static float PowerCD = 15;
    public static float PowerProduce = 3;


    public static float HPTower = 100;

    //Shield
    public static float HPShield = 750;

    //Cammo
    public static float PriceCammo = 100;

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
    public static float EnemyAttack2 = 20;
    public static float EnemyMovespeed2 = 1.5f;
    public static float AttackCD2 = 0.5f;
    public static float EnemyAttack2Pre = 0.2f;
    public static float EnemyAttack2After = 0.3f;

    // 屠夫
    public static float HPEnemy3 = 800;
    public static float vFactor3 = 1.0f;
    public static float EnemyAttack3 = 90;
    public static float EnemyMovespeed3 = 0.5f;
    public static float EnemyAttack3Pre = 2f;
    public static float EnemyAttack3After = 1.8f;
    public static float AttackCD3;


    // 血刃
    public static float HPEnemy4 = 300;
    public static float vFactor4 = 1.0f;
    public static float EnemyAttack4 = 25;
    public static float EnemyMovespeed4 = 2f;
    public static float EnemyAttack4Pre = 0.4f;
    public static float EnemyAttack4After = 0.7f;
    public static float AttackCD4;

    // 血骑士
    public static float HPEnemy5 = 2500;
    public static float vFactor5 = 1.0f;
    public static float EnemyAttack5 = 100;
    public static float EnemyMovespeed5 = 0.6f;
    public static float EnemyAttack5Pre = 1.3f;
    public static float EnemyAttack5After = 0.9f;
    public static float AttackCD5;

    // 可汗
    public static float HPEnemy6 = 30000;
    public static float vFactor6 = 1.0f;
    public static float EnemyAttack6 = 300;
    public static float EnemyMovespeed6 = 0.5f;
    public static float EnemyAttack6Pre = 0.8f;
    public static float EnemyAttack6After = 1.2f;
    public static float AttackCD6;
    // Towers
    // 注意改new float[行, 列]的行、列值
    /* 塔编号目录
     * new float[塔编号, 等级(0开始)]
     * 0. 箭塔
     * 1. 快速低伤箭塔
     * 2. 爆破塔
     * 3. 冰冻塔
     * 4. 穿刺塔
    */
    public static float[,] towerHealth = new float[5, 3]
    {{150f, 200f, 300f}, {150f, 200f, 300f}, {200f, 300f, 450f}, {100f, 150f, 250f}, {100f, 150f, 250f}};
    public static float[,] towerRange = new float[5, 3]
    {{4f, 5f, 6f}, {6f, 7.5f, 9f}, {3f, 4f, 5f}, {4f, 5f, 6f}, {6f, 7.5f, 9f}};
    public static float[] towerRangeNightFactor = new float[5]
    {0.75f, 0.75f, 0.75f, 0.9f, 0.4f};
    public static float[,] towerShootSpeed = new float[5, 3]
    {{1f, 1.5f, 2f}, {4f, 5f ,7f}, {0.75f, 1f, 1.5f}, {1f, 1.5f, 2f}, {0.75f, 1f, 1.5f}};
    public static float[,] towerRotateSpeed = new float[5, 3]
    {{90f, 105f, 120f}, {120f, 135f, 150f}, {75f, 90f, 105f}, {120f, 135f, 150f}, {60f, 65f, 75f}};
    public static float[,] towerDamage = new float[5, 3]
    {{12f, 15f, 20f}, {2.5f, 3f, 4f}, {35f, 60f, 90f}, {2f, 2f, 2.5f}, {10f, 12f, 15f}};
    public static float[] towerDamageNightFactor = new float[5]
    {1.3f, 1.3f, 1.6f, 1.3f, 1.2f};
    public static float[,] towerBulletSpeed = new float[5, 3]
    {{8f, 9f, 10f}, {12f, 13f, 14f}, {6f, 7f, 8f}, {6f, 7f, 8f}, {18f, 24f, 30f}};
    public static float[,] towerPowerConsumption = new float[5, 3]
    {{0f, 0f, 0f}, {0f, 0f, 0f}, {2f, 3f, 4f}, {2f, 3f, 4f}, {3f, 3f, 3f}};
    public static float[,] towerUpgradeCost = new float[5, 3]
    {{45f, 60f, 90f}, {70f, 90f, 120f}, {100f, 150f, 200f}, {100f, 150f, 200f}, {120f, 160f, 200f}};

    // Wall
    public static float[] wallHealth = new float[3]
    {750f, 1000f, 2000f};
    public static float[] wallRecovery = new float[3]
    {0f, 10f, 30f};
    public static float[] wallPowerConsumption = new float[3]
    {0f, 1f, 2f};
    public static float[] wallUpgradeCost = new float[3]
    {30f, 50f, 75f};

    //  Bullet
    // [塔编号, 塔等级]子弹伤害、速度
    // 子弹的伤害、速度写在了Towers里（上面）
}
