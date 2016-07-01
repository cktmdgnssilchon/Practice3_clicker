﻿using UnityEngine;
using System.Collections;
 
public class BattleStateMachineManager
{
    public void Init()
    {
        BattleStateMachine state = null;
 
        for (BattleStateIndex index = BattleStateIndex.None + 1; index < BattleStateIndex.Max; ++index)
        {
            Util.CreateInstanceToString<BattleStateMachine>(ref state, string.Format("{0}State", index.ToString()));
            state.Init(index);
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
 
    public virtual void SetState(BattleStateIndex state)
    {
        m_prevState = m_currState;
        m_currState = m_states[(int)state];
        if (null != m_prevState)
        {
            m_prevState.Exit();
        }           
        m_currState.Enter();
    }
 
    public bool IsCurrState(BattleStateIndex state)
    {
        if (null == m_currState)
            return false;
 
        if (m_currState.GetStateIndex() == state)
            return true;
 
        return false;
    }
 
    public bool IsPrevState(BattleStateIndex state)
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
 
    BattleStateMachine m_currState;
    BattleStateMachine m_prevState;
    BattleStateMachine[] m_states = new BattleStateMachine[(int)BattleStateIndex.Max];
}