using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public static class Util
{
    public static void SetGlobalManagerByAwake()
    {
        GameObject noRemoveManager = GameObject.Find("NoRemoveManager");
        if (null == noRemoveManager)
        {
            noRemoveManager = new GameObject("NoRemoveManager");
            MonoBehaviour.DontDestroyOnLoad(noRemoveManager);
        }
 
        if (null == noRemoveManager.GetComponent<FFMonoBehaviourManager>())
        {
            noRemoveManager.AddComponent<FFMonoBehaviourManager>();
        }
 
        if (null == noRemoveManager.GetComponent<ResourceManager>())
        {
            noRemoveManager.AddComponent<ResourceManager>();
        }
 
        if (null == noRemoveManager.GetComponent<SoundManager>())
        {
            noRemoveManager.AddComponent<SoundManager>();
        }

        if (null == noRemoveManager.GetComponent<GameInfo>())
        {
            noRemoveManager.AddComponent<GameInfo>();
        }
    }

    static public void CreateInstanceToString<T>(ref T instance, string classMame)
    {
        Assembly assem = typeof(T).Assembly;
        instance = (T)assem.CreateInstance(classMame, false, BindingFlags.ExactBinding, null, null, null, null);
        if (instance == null)
            Debug.Log(string.Format("{0} Class not Found!", classMame));
    }

    public static void AddDamageLabelEffect(int value, Transform ownerTransfrom)
    {
        GameObject assetObject = ResourceManager.Instance.ClonePrefab("DamageLabel");
        DamageLabelEffect effect = assetObject.GetComponent<DamageLabelEffect>();
        effect.SetEffect(ownerTransfrom, value);
    }

    static public UIRoot GetUiRoot()
    {
        UIRoot root = null;
        for (int i = 0; i < UIRoot.list.Count; ++i)
        {
            if (UIRoot.list[i].name == "UI Root (2D)")
            {
                root = UIRoot.list[i];
                break;
            }
        }
        return root;
    }

}

