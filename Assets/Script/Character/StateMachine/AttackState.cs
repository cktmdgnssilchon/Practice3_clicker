using UnityEngine;
using System.Collections;

public class AttackState : CharacterStateMachine
{
    public override void Enter()
    {
        m_owner.SetAnimation("Attack", false);
    }

    public override void Exit()
    {
    }

    public override void UpdateFrame()
    {
        if (m_owner.IsEndAnimation())
        {
            m_owner.SetState(UnitStateIndex.Damage);
        }
    }
}