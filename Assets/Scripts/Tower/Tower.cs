using UnityEngine;

public class Tower : MonoBehaviour
{
    // ��������
    public string towerName;
    public int damage;
    public float range;
    public float fireRate;

    private void OnMouseDown()
    {
        // ��⵽����¼�ʱ������UI���
        UIManager.Instance.ShowTowerInfo(this);
    }
}
