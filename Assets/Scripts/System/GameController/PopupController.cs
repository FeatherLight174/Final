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
        // ���浯������� Collider2D ���
        if (Sell != null)
        {
            popupCollider = Sell.GetComponent<Collider2D>();
            Sell.SetActive(false); // ��ʼʱ���ص���
        }
        Upgrade.SetActive(false);
        Range.SetActive(false);
    }

    void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ��ȡ�����λ��
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // �����2D������ȷ��Z��λ��Ϊ0
            
            // ��������Ѽ����ҵ���ڵ��������ϣ�ֱ�ӷ���
            if (Sell.activeSelf && popupCollider != null && gameObject.GetComponent<Collider2D>().OverlapPoint(mousePosition) && Upgrade.activeSelf &&(Range == null || Range.activeSelf))
            {
                return;
            }
            if(Range != null && Range.activeSelf)
            {
                Range.SetActive(false) ;
            }
            // ��������Ѽ����ҵ���ڵ��������ⲿ�����ص���
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
            // ���Ե����������
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                // �ڴ˴�����������չʾ��Ϣ���߼�
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
