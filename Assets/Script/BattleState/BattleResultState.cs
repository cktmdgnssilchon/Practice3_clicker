using UnityEngine;
using System.Collections;
 
public class BattleResultState : BattleStateMachine
{
    public override void Enter()
    {
        FFMonoBehaviour.Destroy(GameScene.Instance.m_enemy.gameObject);
        GameScene.Instance.battleStateManager.SetState(BattleStateIndex.BattleReady);
    }
 
    public override void Exit()
    {       
    }
 
    public override void UpdateFrame()
    {
    }
}