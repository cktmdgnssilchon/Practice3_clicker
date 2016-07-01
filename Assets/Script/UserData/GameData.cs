using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Text;
using System.IO;

public class GameData
{
    public void FirstSetting()
    {
    }

    public void SyncTime()
    {
    }

    public void VictoryStage()
    {
        if (m_saveData.maxClearStageIndex < m_saveData.currStageIndex)
            m_saveData.maxClearStageIndex = m_saveData.currStageIndex;
        ++m_saveData.currStageIndex;
    }

    public GameSaveData saveData
    {
        get { return m_saveData; }
    }

    GameSaveData m_saveData = new GameSaveData();
}