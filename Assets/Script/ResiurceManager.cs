using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : FFMonoBehaviour
{
    private static ResourceManager instance;

    public static ResourceManager Instance
    {
        get
        {
            return instance;
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void Awake()
    {
        base.Awake();

        instance = this;
        LoadAllPrefab();
    }

    public void LoadAllPrefab()
    {
        object[] t0 = Resources.LoadAll("Prefabs");
        for (int i = 0; i < t0.Length; i++)
        {
            GameObject t1 = (GameObject)(t0[i]);
            if (m_commonPrefab.ContainsKey(t1.name))
                continue;

            m_commonPrefab[t1.name] = t1;
        }
    }

    public void LoadPrefabFloder(string subfolder)
    {
        object[] t0 = Resources.LoadAll(subfolder);
        for (int i = 0; i < t0.Length; i++)
        {
            GameObject t1 = (GameObject)(t0[i]);
            if (m_prefab.ContainsKey(t1.name))
                continue;
            m_prefab[t1.name] = t1;
        }
    }

    public void LoadPrefab(string objectPath)
    {
        GameObject gameObject = (GameObject)Resources.Load(objectPath, typeof(GameObject));
        m_prefab.Add(gameObject.name, gameObject);
    }

    public void RemoveAllPrefab()
    {
        if (m_prefab.Count == 0)
            return;
        m_prefab.Clear();
    }

    public GameObject ClonePrefab(string key)
    {
        GameObject t0 = null;
        if (m_commonPrefab.ContainsKey(key))
        {
            t0 = (GameObject)(GameObject.Instantiate(m_commonPrefab[key]));
        }
        else if (m_prefab.ContainsKey(key))
        {
            t0 = (GameObject)(GameObject.Instantiate(m_prefab[key]));
        }

        if (t0 == null)
        {
            Debug.Log(string.Format("ResourceManager Clone is failed, [key={0}]", key));
            return null;
        }

        t0.name = key + "_Clone";
        return t0;
    }

    private Dictionary<string, GameObject> m_prefab = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_commonPrefab = new Dictionary<string, GameObject>();
}