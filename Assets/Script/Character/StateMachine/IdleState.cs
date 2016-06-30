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

    public override void UpdateFrame()
    {

        if (m_owner.IsEndAnimation())
        {
            m_owner.SetState(UnitStateIndex.Idle);
        }
    }
}