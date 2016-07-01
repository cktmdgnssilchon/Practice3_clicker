using UnityEngine;
using System.Collections;

public class DamageLabelEffect : FFMonoBehaviour
{
    public override void Awake()
    {
        base.Awake();
        UIRoot root = Util.GetUiRoot();
        Transform cameratransform = root.transform.FindChild("Camera");
        m_mainCamera = Camera.main;
        m_uiCamera = cameratransform.GetComponent<Camera>();
        m_transform = transform;

        m_transform.parent = cameratransform.transform;
        m_transform.localPosition = m_transform.localPosition;
        m_transform.localRotation = Quaternion.identity;
        m_transform.localScale = Vector3.one;
    }

    public void SetEffect(Transform ownerTransform, int damage)
    {
        m_ownerTransform = ownerTransform;
        m_damageLabel.text = damage.ToString();
        Update();
    }

    public void Update()
    {
        if (m_ownerTransform == null)
            return;

        Vector3 pos = m_ownerTransform.position;
        pos.y += 0.8f;

        Vector3 viewportPoint = m_mainCamera.WorldToViewportPoint(pos);
        viewportPoint.z = 0;

        Vector3 transPos = m_uiCamera.ViewportToWorldPoint(viewportPoint);
        m_transform.position = transPos;
    }

    public void EndPos()
    {
        Destroy(gameObject);
    }

    public UILabel m_damageLabel;
    Transform m_ownerTransform;
    Transform m_transform;
    Camera m_mainCamera;
    Camera m_uiCamera;
}