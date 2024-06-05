using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] Slider sliderBGM;
    [SerializeField] Slider sliderSFX;

    void Start()
    {
        if(!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", Mathf.Log10(0.4f) * 20f);
        } else{
            LoadVolumeBGM();
        }
        
        if(!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", Mathf.Log10(0.4f) * 20f);
        } else{
            LoadVolumeSFX();
        }
    }

    public void SetSFXVolume(float level)
    {
        //Mathf.Log10(level) * 20f is responsible for properly set the volume change in a linear way
        float volume = Mathf.Log10(level) * 20f;
        audioMixer.SetFloat("SFXVolume", volume);
        SaveVolumeSFX(volume);
    }

    public void SetBGMVolume(float level)
    {
        float volume = Mathf.Log10(level) * 20f;
        audioMixer.SetFloat("BGMVolume", volume);
        SaveVolumeBGM(volume);
    }

    private void SaveVolumeSFX(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void SaveVolumeBGM(float volume)
    {
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    private void LoadVolumeSFX()
    {
        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }

    private void LoadVolumeBGM()
    {
        audioMixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
    }
}
