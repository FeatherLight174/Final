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

            // 延迟销毁对象，确保音效播放完毕
            Destroy(gameObject, destroy.clip.length);
        }
        else
        {
            // 如果没有destroy音源，直接销毁对象
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
