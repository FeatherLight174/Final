using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject Sell;
    private Collider2D popupCollider;
    public GameObject Upgrade;
    public GameObject Range;

    private int m_firstTime = 1;

    void Start()
    {
        // 缓存弹窗物体的 Collider2D 组件
        if (Sell != null)
        {
            popupCollider = Sell.GetComponent<Collider2D>();
            Sell.SetActive(false); // 开始时隐藏弹窗
        }
        Upgrade.SetActive(false);
        Range.SetActive(false);
    }

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 如果是2D弹窗，确保Z轴位置为0
            
            // 如果弹窗已激活且点击在弹窗物体上，直接返回
            if (Sell.activeSelf && popupCollider != null && gameObject.GetComponent<Collider2D>().OverlapPoint(mousePosition) && Upgrade.activeSelf &&(Range == null || Range.activeSelf))
            {
                return;
            }
            if(Range != null && Range.activeSelf)
            {
                Range.SetActive(false) ;
            }
            // 如果弹窗已激活且点击在弹窗物体外部，隐藏弹窗
            if (Sell.activeSelf || Upgrade.activeSelf)
            {
                Sell.SetActive(false);
                Upgrade.SetActive(false);
                return;
            }
            if (!gameObject.GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                Debug.Log("sssss");
                return;
            }
            // 尝试点击其他物体
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                // 在此处处理点击物体展示信息的逻辑
                Sell.SetActive(true);
                Upgrade.SetActive(true);
                Range.SetActive(true);
            }

            if(m_firstTime != 0)
            {
                Sell.SetActive(false);
                Upgrade.SetActive(false);
                Range.SetActive(false);
                m_firstTime = 0;
            }
        }
    }
}
