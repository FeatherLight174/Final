using UnityEngine;

public class Tower : MonoBehaviour
{
    // 塔的属性
    public string towerName;
    public int damage;
    public float range;
    public float fireRate;

    private void OnMouseDown()
    {
        // 检测到点击事件时，更新UI面板
        UIManager.Instance.ShowTowerInfo(this);
    }
}
