using UnityEngine;
using System.Collections;
 
public class Enemy : FFMonoBehaviour
{
    public override void Awake()
    {
        base.Awake();
        m_myTransform = transform;
 
        m_maxHp = 100;
        m_currHp = 100;

        m_shaking = gameObject.AddComponent<Shaking>();
        m_shaking.Init(m_model);

        m_shader = gameObject.AddComponent<VisualShader>();
        m_shader.SetOwner(m_model.transform);

        m_material = m_model.GetComponent<Renderer>().material; //랜덤하게 한장 가져와서 머티리얼 설정

        m_hide = new DelegateEndHide(EndHide); //죽었을때 하이드 호출
    }
 
    public void Init()
    {
        m_maxHp = 100;
        m_currHp = 100;

        //m_maxHp += GameInfo.Instance.gameData.saveData.currStageIndex * 10;
        //m_currHp += GameInfo.Instance.gameData.saveData.currStageIndex * 10;

        if (GameInfo.Instance.gameData.saveData.currStageIndex % 5 == 0)
        {
            m_maxHp *= 5;
            m_currHp *= 5;
        }

        GameScene.Instance.m_hpLabel.text = m_currHp.ToString();
        GameScene.Instance.m_hpBar.sliderValue = 1;

        int enemyRandomValue = UnityEngine.Random.Range(1, 11);
        m_material.mainTexture = (Texture2D)Resources.Load(string.Format("Texture/Enemy/Enemy{0}", enemyRandomValue), typeof(Texture2D));
    }
 
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void SetDamage(int damage)
    {
        if (m_dead)
            return;

        m_currHp -= damage;

        if (m_currHp <= 0)
        {
            m_currHp = 0;
            m_dead = true;
            m_shader.Hide(m_hide);
            SoundManager.Instance.PlayActionSound("Dead");
            GameInfo.Instance.gameData.VictoryStage();
        }
        m_shaking.SetShaking(3, 0.3f);
        m_shader.SetRimColor(Color.red);
        SoundManager.Instance.PlayActionSound("Peok");
        GameScene.Instance.m_hpBar.sliderValue = (float)currHp / (float)maxHp;
        GameScene.Instance.m_hpLabel.text = currHp.ToString();
        Util.AddDamageLabelEffect(damage, m_myTransform);
    }

    public void EndHide()
    {
        GameScene.Instance.battleStateManager.SetState(BattleStateIndex.BattleResult);
    }


    public Transform myTransform
    {
        get { return m_myTransform; }
    }
 
    public int currHp
    {
        get { return m_currHp; }
        set { m_currHp = value; }
    }
 
    public int maxHp
    {
        get { return m_maxHp; }
        set { m_maxHp = value; }
    }
 
    public GameObject m_model;
    public UISlider m_hpBar;
    Transform m_myTransform;
    int m_currHp = 100;
    int m_maxHp = 100;
    bool m_dead;

    Shaking m_shaking;
    VisualShader m_shader;
    Material m_material;
    DelegateEndHide m_hide;
}