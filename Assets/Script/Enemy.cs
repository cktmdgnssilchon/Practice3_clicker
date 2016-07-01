using UnityEngine;
using System.Collections;
 
public class Enemy : FFMonoBehaviour
{
    public override void Awake()
    {
        base.Awake();
        m_myTransform = transform;
 
        m_maxHp = 100;
        m_currHp = 100;
    }
 
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
 
    public void SetDamage(int damage)
    {
        if (m_currHp <= 0)
        {
            return;
        }
 
        m_currHp -= damage;
 
        m_hpBar.sliderValue = (float)m_currHp / (float)m_maxHp;
    }
 
    public Transform myTransform
    {
        get { return m_myTransform; }
    }
 
    public int currHp
    {
        get { return m_currHp; }
        set { m_currHp = value; }
    }
 
    public int maxHp
    {
        get { return m_maxHp; }
        set { m_maxHp = value; }
    }
 
    public GameObject m_model;
    public UISlider m_hpBar;
    Transform m_myTransform;
    int m_currHp = 100;
    int m_maxHp = 100;
    
}