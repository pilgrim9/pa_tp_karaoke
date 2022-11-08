using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class LoadMuteValue : MonoBehaviour
{
    Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

    }

    private void Start()
    {
        toggle.isOn = PlayerPrefManager.instance.GetIsMuted();
    }
    public void IsOnByVolume(float volume)
    {
        toggle.isOn = volume == 0;
    }
}
