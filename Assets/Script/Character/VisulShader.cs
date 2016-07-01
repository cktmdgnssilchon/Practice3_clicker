using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void DelegateEndHide();

public class VisualShader : MonoBehaviour
{
    public void SetOwner(Transform owner)
    {
        m_owner = owner;
        CollectRenderer(owner.gameObject);
        m_activeRimPower = false;
    }

    public void SetRimColor(Color color)
    {
        m_power = 1;
        RimColor(m_owner, color);
        m_activeRimPower = true;
    }

    public void Hide(DelegateEndHide delegateHide)
    {
        m_delegateHide = delegateHide;
        m_alpha = 1;
        m_activeHide = true;
    }

    void Update()
    {
        ProcessRimPower();
        ProcessHide();
    }

    void ProcessRimPower()
    {
        if (m_activeRimPower == false)
            return;

        if (m_owner == null)
            return;

        m_power -= Time.deltaTime * 2;
        if (m_power <= 0)
        {
            m_power = 0;
            m_activeRimPower = false;
        }

        RimPower(m_owner);
    }

    void ProcessHide()
    {
        if (m_activeHide == false)
            return;

        if (m_owner == null)
            return;

        m_alpha -= Time.deltaTime * 2;
        if (m_alpha <= 0)
        {
            m_alpha = 0;
            m_activeHide = false;
            m_delegateHide();
        }

        Alpha(m_owner);
    }

    void RimPower(Transform owner)
    {
        for (int i = 0; i < m_rendererList.Count; ++i)
        {
            m_rendererList[i].material.SetFloat("_RimPower", m_power);
        }
    }

    void RimColor(Transform owner, Color color)
    {
        for (int i = 0; i < m_rendererList.Count; ++i)
        {
            m_rendererList[i].material.SetColor("_RimColor", color);
        }
    }

    void Alpha(Transform owner)
    {
        for (int i = 0; i < m_rendererList.Count; ++i)
        {
            m_rendererList[i].material.SetFloat("_Alpha", m_alpha);
        }
    }

    void CollectRenderer(GameObject owner)
    {
        Renderer renderer = owner.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            m_rendererList.Add(renderer);
        }

        for (int i = 0; i < owner.transform.childCount; ++i)
        {
            CollectRenderer(owner.gameObject.transform.GetChild(i).gameObject);
        }
    }

    bool m_activeRimPower;
    bool m_activeHide;
    Transform m_owner;
    float m_power;
    float m_alpha;
    List<Renderer> m_rendererList = new List<Renderer>();
    DelegateEndHide m_delegateHide;
}