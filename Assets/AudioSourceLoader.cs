using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceLoader : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefManager.instance.GetVolume() / (float)PlayerPrefManager.DEFAULT_VOLUME;
        audioSource.time = PlayerPrefManager.instance.GetPlaybackTime();
        InvokeRepeating(nameof(SavePlaybackTime), 1f, 1f);
        audioSource.Play();
    }

    private void SavePlaybackTime()
    {
        PlayerPrefManager.instance.SetPlaybackTime(audioSource.time);
    }
}
