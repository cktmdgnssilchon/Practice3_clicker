using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FFMonoBehaviourManager : MonoBehaviour
{
    private static FFMonoBehaviourManager instance;

    public static FFMonoBehaviourManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;

        for (int i = 1; i < 2000; ++i)
        {
            m_classIdGenerator.Add(i);
        }
    }

    public void FixedUpdate()
    {
        m_elapsedTime += Time.fixedDeltaTime / Time.timeScale;
        if (m_elapsedTime < 1)
            return;

        m_elapsedTime -= 1;

        if (m_classList.Count != 0)
        {
            Dictionary<int, FFMonoBehaviour>.Enumerator rator = m_classList.GetEnumerator();
            while (rator.MoveNext())
            {
                FFMonoBehaviour beHavior = rator.Current.Value;
                if (beHavior == null)
                {
                    continue;
                }
                beHavior.UpdateOneSecond();
            }
        }
    }

    void Update()
    {
    }

    void LateUpdate()
    {
        m_occurEvent = true;
        if (m_classList.Count != 0)
        {
            while (true)
            {
                if (m_occurMessageList.Count == 0)
                    break;

                EventActionMessgeInfo info = m_occurMessageList[0];
                Dictionary<int, FFMonoBehaviour>.Enumerator rator = m_classList.GetEnumerator();
                while (rator.MoveNext())
                {
                    FFMonoBehaviour beHavior = rator.Current.Value;
                    if (beHavior == null)
                    {
                        continue;
                    }

                    beHavior.OccurEventActionMessage(info._msg, info._param);
                }
                m_occurMessageList.RemoveAt(0);
            }
        }
        m_occurEvent = false;

        if (m_removeClass.Count != 0)
        {
            Dictionary<int, FFMonoBehaviour>.Enumerator rator = m_removeClass.GetEnumerator();
            while (rator.MoveNext())
            {
                if (ReturnClassIndex(rator.Current.Key) == false)
                {
                    FFMonoBehaviour beHavior = rator.Current.Value;
                    if (beHavior)
                        Debug.Log(string.Format("{0}Class Id Error!1", beHavior.name));
                }
                m_classList.Remove(rator.Current.Key);
            }
            m_removeClass.Clear();
        }

        if (m_prepareAwakeList.Count != 0)
        {
            for (int i = 0; i < m_prepareAwakeList.Count; ++i)
            {
                FFMonoBehaviour beHavior = m_prepareAwakeList[i];
                beHavior.classIndex = GenerateClassIndex();
                if (beHavior.classIndex == 0)
                {
                    Debug.Log(beHavior.name);
                }
                m_classList.Add(beHavior.classIndex, beHavior);
            }
            m_prepareAwakeList.Clear();
        }
    }

    public void CreateClass(FFMonoBehaviour havior)
    {
        if (m_occurEvent == false)
        {
            havior.classIndex = GenerateClassIndex();
            if (havior.classIndex == 0)
            {
                Debug.Log(havior.name);
            }
            m_classList.Add(havior.classIndex, havior);
        }
        else
            m_prepareAwakeList.Add(havior);
    }

    public void RemoveClass(int index)
    {
        if (m_removeClass.ContainsKey(index))
        {
            FFMonoBehaviour haviour = (FFMonoBehaviour)m_removeClass[index];
            if (haviour != null)
                Debug.Log(haviour.name);
            else
            {
                Debug.Log("RemoveClass Duplicate Add 0!!!!!!!!");
                return;
            }
        }

        if (m_classList.ContainsKey(index) == false)
        {
            Debug.Log(string.Format("RemoveClass noClass!! 0!!!!!!!!", index));
            return;
        }

        m_removeClass.Add(index, m_classList[index]);
    }

    int GenerateClassIndex()
    {
        int index = m_classIdGenerator[0];
        m_classIdGenerator.RemoveAt(0);
        if (index == 0)
        {
            Debug.Log(string.Format("GenerateClassIndex index= 0, classidnum={0}", m_classIdGenerator.Count));
        }
        return index;
    }

    bool ReturnClassIndex(int classIndex)
    {
        if (m_classIdGenerator.Contains(classIndex))
        {
            return false;
        }

        m_classIdGenerator.Add(classIndex);
        return true;
    }

    public void SendEventActionMessage(EventMessage msg, params object[] paramList)
    {
        if (m_addOccurEvent == true)
        {
            Debug.Log(msg);
            Debug.Break();
        }

        m_addOccurEvent = true;

        EventActionMessgeInfo info = new EventActionMessgeInfo();
        info._msg = msg;
        info._param = paramList;
        m_occurMessageList.Add(info);

        m_addOccurEvent = false;
    }

    void OnApplicationPause(bool pause)
    {
    }

    void OnApplicationQuit()
    {
    }

    //void OnApplicationFocus(bool focusStatus)
    //{
    //}

    public class EventActionMessgeInfo
    {
        public EventMessage _msg;
        public object[] _param;
    }

    float m_elapsedTime = 0;
    bool m_occurEvent = false;
    bool m_addOccurEvent = false;
    List<EventActionMessgeInfo> m_occurMessageList = new List<EventActionMessgeInfo>();
    List<int> m_classIdGenerator = new List<int>();
    List<FFMonoBehaviour> m_prepareAwakeList = new List<FFMonoBehaviour>();
    Dictionary<int, FFMonoBehaviour> m_classList = new Dictionary<int, FFMonoBehaviour>();
    Dictionary<int, FFMonoBehaviour> m_removeClass = new Dictionary<int, FFMonoBehaviour>();
}