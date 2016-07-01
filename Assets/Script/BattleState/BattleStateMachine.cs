using UnityEngine;
using System.Collections;
 
public class BattleStateMachine
{
    public virtual void Init( BattleStateIndex stateIndex )
    {
        m_stateIndex = stateIndex;
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
 
    public BattleStateIndex GetStateIndex()
    {
        return m_stateIndex;
    }
 
    public virtual void OccurEventActionMessage(EventMessage msg, params object[] paramList)
    {
 
    }
 
    BattleStateIndex m_stateIndex;
    protected float m_currTime;
}