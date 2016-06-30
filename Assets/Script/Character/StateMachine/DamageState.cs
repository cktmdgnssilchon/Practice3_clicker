using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageState : CharacterStateMachine
{
    public override void Enter()
    {
        m_owner.SetAnimation("Damage", false);
    }

    public override void Exit()
    {
    }

    public override void UpdateFrame()
    {
        if (m_owner.IsEndAnimation())
        {
            m_owner.SetState(UnitStateIndex.Dead);
        }
    }
}