using UnityEngine;
using System.Collections;

public class DeadState : CharacterStateMachine
{
    public override void Enter()
    {
        m_owner.SetAnimation("Dead", false);
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