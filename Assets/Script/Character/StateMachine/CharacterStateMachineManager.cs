using UnityEngine;
using System.Collections;

public class CharacterStateMachineManager
{
    public void Init(Character owner)
    {
        CharacterStateMachine state = null;

        for (UnitStateIndex index = UnitStateIndex.Idle; index < UnitStateIndex.Max; ++index)
        {
            Util.CreateInstanceToString<CharacterStateMachine>(ref state, string.Format("{0}State", index.ToString()));
            state.Init(index, owner);
            m_states[(int)index] = state;
        }
    }

    public void Release()
    {
        m_states = null;
    }

    public void UpdateFrame()
    {
        if (null == m_currState)
            return;

        m_currState.UpdateFrame();
    }

    public void AfterUpdateFrame()
    {
        if (null == m_currState)
            return;

        m_currState.AfterUpdateFrame();
    }

    public virtual void SetState(UnitStateIndex state)
    {
        m_prevState = m_currState;
        m_currState = m_states[(int)state];
        if (null != m_prevState)
        {
            m_prevState.Exit();
        }
        m_currState.Enter();
    }

    public bool IsCurrState(UnitStateIndex state)
    {
        if (null == m_currState)
            return false;

        if (m_currState.GetStateIndex() == state)
            return true;

        return false;
    }

    public bool IsPrevState(UnitStateIndex state)
    {
        if (null == m_prevState)
            return false;

        if (m_prevState.GetStateIndex() == state)
            return true;

        return false;
    }

    public void OccurEventActionMessage(EventMessage msg, params object[] paramList)
    {
        if (m_currState == null)
            return;

        m_currState.OccurEventActionMessage(msg, paramList);
    }

    CharacterStateMachine m_currState;
    CharacterStateMachine m_prevState;
    CharacterStateMachine[] m_states = new CharacterStateMachine[(int)UnitStateIndex.Max];
}