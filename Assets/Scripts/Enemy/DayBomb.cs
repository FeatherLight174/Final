using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayBomb : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer sp;
    public float fadeSpeed = 1f;
    private float m_timer = 0;
    private float m_timer2 = 0;
    private float m_timer3 = 0;
    private bool hasExisted = false;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Clock.Day == 2) && (Clock.NowHour == 8)) {
            animator.SetBool("hasExisted", true);
            m_timer += Time.deltaTime;
            if (m_timer <= 1)
            {

                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a + fadeSpeed * Time.deltaTime);
            }
            else if (m_timer > 1)
            {
                hasExisted = true;
            }

        }
        if (hasExisted)
        {
            
            m_timer2+= Time.deltaTime;
            if(m_timer2 >= 4.5)
            {
                m_timer3+= Time.deltaTime; 
                if(m_timer3 <= 1)
                {
                    sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - fadeSpeed * Time.deltaTime);
                }
                
            }
        }
    }
}
