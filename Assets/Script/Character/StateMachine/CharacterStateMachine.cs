using UnityEngine;
using System.Collections;

public class CharacterStateMachine
{
    public virtual void Init(UnitStateIndex stateIndex, Character owner)
    {
        m_stateIndex = stateIndex;
        m_owner = owner;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void UpdateFrame()
    {
    }

    public virtual void AfterUpdateFrame()
    {

    }

    public UnitStateIndex GetStateIndex()
    {
        return m_stateIndex;
    }

    public virtual void OccurEventActionMessage(EventMessage msg, params object[] paramList)
    {

    }

    UnitStateIndex m_stateIndex;
    protected Character m_owner;
    protected float m_currTime;
}