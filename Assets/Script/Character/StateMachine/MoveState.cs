using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveState : CharacterStateMachine
{
    public override void Enter()
    {
        m_owner.SetAnimation("Walk", true);
        m_currTime = 0;
    }

    public override void Exit()
    {
    }

    public override void UpdateFrame()
    {
        m_currTime += Time.deltaTime;
        if (m_currTime >= 1)
        {
            m_owner.SetState(UnitStateIndex.Attack);
        }
    }
}