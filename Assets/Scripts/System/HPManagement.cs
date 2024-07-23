using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManagement : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public AudioSource destroy;

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            PlayDeathSound();
            HP = 0;
        }
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    void PlayDeathSound()
    {
        if (destroy != null && !destroy.isPlaying)
        {
            destroy.Play();
            //Debug.Log("DIE12457579789");

            // �ӳ����ٶ���ȷ����Ч�������
            Destroy(gameObject, destroy.clip.length);
        }
        else
        {
            // ���û��destroy��Դ��ֱ�����ٶ���
            if (destroy != null)
            {
                Destroy(gameObject, destroy.clip.length);
            }
            else
            {
                Destroy(gameObject,0.5f);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    public void SetHP(float MAX)
    {
        MaxHP = MAX;
        HP = HP / MaxHP * MAX;
    }
}
