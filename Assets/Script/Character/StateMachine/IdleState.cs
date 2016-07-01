using UnityEngine;
using System.Collections;

public class IdleState : CharacterStateMachine
{
    public override void Enter()
    {
        m_owner.SetAnimation("Wait", true);
        m_currTime = 0;
    }

    public override void Exit()
    {
    }

    //대기
    //public override void UpdateFrame()
    //{
    //    if (m_owner.IsEndAnimation())
    //    {
    //        m_owner.SetState(UnitStateIndex.Idle);
    //    }
    //}

    //알아서 공격
    public override void UpdateFrame()
    {
        m_currTime += Time.deltaTime;
        if (m_currTime < m_owner.attackSpeed)
            return;
 
        m_owner.SetState(UnitStateIndex.Attack);       
    }
}