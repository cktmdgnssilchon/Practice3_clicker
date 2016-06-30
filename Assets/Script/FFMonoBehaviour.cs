using UnityEngine;
using System.Collections;

public class FFMonoBehaviour : MonoBehaviour
{
    public FFMonoBehaviour()
    {
    }

    public virtual void Awake()
    {
#if UNITY_EDITOR
        if (Application.isPlaying == false)
            return;
#endif
        if (FFMonoBehaviourManager.Instance == null)
            Util.SetGlobalManagerByAwake();

        FFMonoBehaviourManager.Instance.CreateClass(this);
    }

    public virtual void OnDestroy()
    {
#if UNITY_EDITOR
        if (Application.isPlaying == false)
            return;
#endif
        FFMonoBehaviourManager.Instance.RemoveClass(m_classIndex);
    }

    public virtual void OccurEventActionMessage(EventMessage msg, params object[] paramList)
    {

    }

    public virtual void UpdateOneSecond()
    {

    }

    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public int classIndex
    {
        get { return m_classIndex; }
        set { m_classIndex = value; }
    }

    int m_classIndex;
}