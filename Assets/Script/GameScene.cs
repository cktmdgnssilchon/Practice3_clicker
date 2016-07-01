using UnityEngine;
using System.Collections;

public class GameScene : FFMonoBehaviour
{

    //싱글톤 사용
    private static GameScene instance;

    public static GameScene Instance
    {
        get
        {
            return instance;
        }
    }


    public override void Awake()
    {
        base.Awake();
        instance = this; //싱글톤 선언

        m_battleStateManager = new BattleStateMachineManager();
        m_battleStateManager.Init();
        m_battleStateManager.SetState(BattleStateIndex.BattleReady);

        m_character.Init();
        m_character.SetState(UnitStateIndex.Idle);
    }

    /* //Character.cs 컴포넌트 링크 걸기 코드로 구현
    public override void Awake()
    {
        instance = this; 
        base.Awake();

        GameObject characterObject = ResourceManager.Instance.ClonePrefab("Finger");
        m_character = characterObject.AddComponent<Character>();
        m_character.Init();
        m_character.SetState(UnitStateIndex.Idle);
    }
    */
    public void Update()
    {
        if (m_character)
        {
            m_character.UpdateFrame();
        }
    }

    public void LateUpdate()
    {
        if (m_character)
        {
            m_character.AfterUpdateFrame();
        }
    }

    //화면 터치 시, 클릭시 캐릭터 공격함(atack state)
    //public void TouchScreen(Vector3 pos)
    //{
    //    m_character.SetState(UnitStateIndex.Attack);
    //}

    //캐릭터 공격은 일정주기, 화면 터치할떄마다 이벤트
    public void TouchScreen(Vector3 pos)
    {
        if (m_enemy == null)
            return;
 
        m_enemy.SetDamage(10);

        //터치 이펙트
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 50)); //50은 카메라거리가 50이라
        GameObject effectObject = ResourceManager.Instance.ClonePrefab("Hit");
        effectObject.transform.position = worldPos;
    }

    public void AttackEvent(int attack)
    {
        if (m_enemy == null)
            return;

        m_enemy.SetDamage(attack);

    }

    public Enemy enemy
    {
        get { return m_enemy; }
        set { m_enemy = value; }
    }
 
    public BattleStateMachineManager battleStateManager
    {
        get { return m_battleStateManager; }
 
    }

    public Character m_character;
    public Enemy m_enemy;
    public UISlider m_hpBar;
    public UILabel m_hpLabel;
    public UILabel m_stageLabel;

    BattleStateMachineManager m_battleStateManager;

}