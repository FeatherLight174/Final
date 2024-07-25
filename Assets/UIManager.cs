using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject infoPanel;
    public Text nameText;
    public Text damageText;
    public Text rangeText;
    public Text fireRateText;

    private void Awake()
    {
        // ȷ��UIManager�ǵ���
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ��ʾ������Ϣ
    /*public void ShowTowerInfo(Tower tower)
    {
        infoPanel.SetActive(true);
        nameText.text = "Name: " + tower.towerName;
        damageText.text = "Damage: " + tower.damage.ToString();
        rangeText.text = "Range: " + tower.range.ToString();
        fireRateText.text = "Fire Rate: " + tower.fireRate.ToString();
    }*/
}

