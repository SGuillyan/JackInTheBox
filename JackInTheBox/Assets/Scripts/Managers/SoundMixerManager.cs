using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetSFXVolume(float level)
    {
        //Mathf.Log10(level) * 20f is responsible for properly set the volume change in a linear way
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetBGMVolume(float level)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(level) * 20f);
    }
}
