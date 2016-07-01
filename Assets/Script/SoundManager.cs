using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class SoundManager : FFMonoBehaviour
{
    private static SoundManager instance;
 
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }
 
    public override void Awake()
    {
        base.Awake();
 
        instance = this;
    }

    void OnApplicationQuit()
    {
        instance = null;
    }
 
    public void Update()
    {
        for (int i = m_actionSoundList.Count -1 ; i >= 0 ; --i)
        {
            if (m_actionSoundList[i].isPlaying)
                continue;
 
            Destroy(m_actionSoundList[i]);
            m_actionSoundList.RemoveAt(i);
        }
    }
 
    public void PlayActionSound(string key)
    {
        if (key == null || key == "")
            return;
 
        object go = Resources.Load(string.Format("Sound/Action/{0}",key), typeof(AudioClip));
        AudioClip obj = (AudioClip)go;
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = m_actionVolume;
        audioSource.spatialBlend = 0;
        audioSource.ignoreListenerVolume = true;
        audioSource.Stop();
        audioSource.clip = obj;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
 
        m_actionSoundList.Add(audioSource);
 
        audioSource.PlayOneShot(audioSource.clip);
    }
 
    float m_actionVolume = 0.8f;
 
    private List<AudioSource> m_actionSoundList = new List<AudioSource>();
}