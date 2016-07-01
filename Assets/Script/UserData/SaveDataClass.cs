using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSaveData
{
    public int currStageIndex
    {
        get { return m_currStageIndex; }
        set { m_currStageIndex = value; }
    }
    public int maxClearStageIndex
    {
        get { return m_maxClearStageIndex; }
        set { m_maxClearStageIndex = value; }
    }

    int m_currStageIndex = 1;
    int m_maxClearStageIndex;
}