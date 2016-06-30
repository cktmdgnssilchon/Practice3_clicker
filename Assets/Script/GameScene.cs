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

    //화면 터치 시
    public void TouchScreen(Vector3 pos)
    {
        m_character.SetState(UnitStateIndex.Attack);
    }

    public void AttackEvent(int attack)
    {
        if (m_enemy == null)
            return;

        m_enemy.SetDamage(attack);

    }

    public Character m_character;
    public Enemy m_enemy;

}