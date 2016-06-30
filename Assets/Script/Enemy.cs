using UnityEngine;
using System.Collections;

public class Enemy : FFMonoBehaviour
{
    public override void Awake()
    {
        base.Awake();
        m_myTransform = transform;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void SetDamage(int damage)
    {
        if (m_hp <= 0)
        {
            return;
        }

        m_hp -= damage;
        Debug.Log(string.Format("{0}의 데미지를 입었습니다. 남은 HP {1}", damage, m_hp));
    }

    public Transform myTransform
    {
        get { return m_myTransform; }
    }

    public int hp
    {
        get { return m_hp; }
        set { m_hp = value; }
    }

    public GameObject m_model;
    Transform m_myTransform;
    int m_hp = 100;
}