using UnityEngine;
using System.Collections;

public class GameInfo : FFMonoBehaviour
{
    private static GameInfo instance;

    public static GameInfo Instance
    {
        get { return instance; }
    }

    public override void Awake()
    {
        base.Awake();

        instance = this;
    }

    public void FirstSetting()
    {
        m_gameData.FirstSetting();
    }

    public void SyncTime()
    {
        m_gameData.SyncTime();
        m_sycnSaveData = true;
    }

    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        m_sycnSaveData = false;
    }

    public bool syncSaveData
    {
        get { return m_sycnSaveData; }
    }
    public GameData gameData
    {
        get { return m_gameData; }
    }

    bool m_sycnSaveData;
    GameData m_gameData = new GameData();
}