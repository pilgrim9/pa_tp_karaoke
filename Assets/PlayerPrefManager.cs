using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerPrefManager : MonoBehaviour
{
    public static readonly string VOLUME = "volume";
    public static readonly string VOLUME_BEFORE_MUTE = "volumeBeforeMute";
    public static readonly string SONG_PLAYBACK_TIME = "songPlaybackTime";
    public static readonly int DEFAULT_VOLUME = 100;
    public static readonly int DEFAULT_PLAYBACK_TIME = 0;
    public static readonly string IS_MUTED = "isMuted";
     
    public static PlayerPrefManager instance;
    public void Awake()
    {
        instance = this;
    }

    public UnityEvent onResetToDefault;
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        PlayerPrefs.SetInt(VOLUME, (int) volume);
    }
    public int GetVolume()
    {
        return PlayerPrefs.GetInt(VOLUME, DEFAULT_VOLUME);
    }

    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            PlayerPrefs.SetInt(VOLUME_BEFORE_MUTE, PlayerPrefs.GetInt(VOLUME, DEFAULT_VOLUME));
            PlayerPrefs.SetInt(VOLUME, 0);
            PlayerPrefs.SetInt(IS_MUTED, 1);
        }
        else
        {
            PlayerPrefs.SetInt(VOLUME, PlayerPrefs.GetInt(VOLUME_BEFORE_MUTE, DEFAULT_VOLUME));
            PlayerPrefs.SetInt(IS_MUTED, 0);
        }
    }

    public bool GetIsMuted()
    {
        return PlayerPrefs.GetInt(IS_MUTED, 0) == 1;
    }
    
    public void SetPlaybackTime(float time)
    {
        PlayerPrefs.SetInt(SONG_PLAYBACK_TIME, (int)time);
    }
    public int GetPlaybackTime()
    {
        return PlayerPrefs.GetInt(SONG_PLAYBACK_TIME, DEFAULT_PLAYBACK_TIME);
    }

    public void SetAllToDefault()
    {
        PlayerPrefs.DeleteAll();
        onResetToDefault.Invoke();
    }
}
