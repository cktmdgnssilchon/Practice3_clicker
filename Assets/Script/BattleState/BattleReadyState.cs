using UnityEngine;
using System.Collections;
 
public class BattleReadyState : BattleStateMachine
{
    public override void Enter()
    {
        GameObject enemyObject = ResourceManager.Instance.ClonePrefab("Enemy");
        GameScene.Instance.enemy = enemyObject.GetComponent<Enemy>();
        GameScene.Instance.enemy.Init();
 
        GameScene.Instance.battleStateManager.SetState(BattleStateIndex.Battle);
    }
 
    public override void Exit()
    {       
    }
 
    public override void UpdateFrame()
    {
    }
}