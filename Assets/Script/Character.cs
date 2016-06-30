using UnityEngine;
using System.Collections;

public class Character : FFMonoBehaviour
{
    public override void Awake()
    {
        base.Awake();

        m_stateMachineManager = new CharacterStateMachineManager();
        m_stateMachineManager.Init(this);
        m_myTransform = transform;

        m_animation = GetComponent<Animation>();
    }

    public void Init()
    {
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void UpdateFrame()
    {
        if (null != m_stateMachineManager)
        {
            m_stateMachineManager.UpdateFrame();
        }
    }

    public void AfterUpdateFrame()
    {
        if (null != m_stateMachineManager)
        {
            m_stateMachineManager.AfterUpdateFrame();
        }
    }

    public void SetState(UnitStateIndex state)
    {
        if (null == m_stateMachineManager)
            return;
        m_stateMachineManager.SetState(state);
    }

    public bool IsCurrState(UnitStateIndex state)
    {
        if (null == m_stateMachineManager)
            return false;
        return m_stateMachineManager.IsCurrState(state);
    }

    public bool IsPrevState(UnitStateIndex state)
    {
        if (null == m_stateMachineManager)
            return false;
        return m_stateMachineManager.IsPrevState(state);
    }

    public Vector3 pos
    {
        get { return m_myTransform.position; }
        set { m_myTransform.position = value; }
    }

    public override void OccurEventActionMessage(EventMessage msg, params object[] paramList)
    {
        if (m_stateMachineManager != null)
        {
            m_stateMachineManager.OccurEventActionMessage(msg, paramList);
        }
    }

    public void SetAnimation(string aniName, bool loop)
    {
        if (loop)
        {
            m_animation[aniName].wrapMode = WrapMode.Loop;
        }
        else
        {
            m_animation[aniName].wrapMode = WrapMode.Once;
        }
        m_animation.CrossFade(aniName);
    }

    public bool IsEndAnimation()
    {
        return !m_animation.isPlaying;
    }

    public Transform myTransform
    {
        get { return m_myTransform; }
    }

    public void AttackEvent()
    {
        GameScene.Instance.AttackEvent(m_attack);
    }

    int m_attack = 10; //캐릭터의 공격력

    Transform m_myTransform;
    CharacterStateMachineManager m_stateMachineManager;
    Animation m_animation;
}