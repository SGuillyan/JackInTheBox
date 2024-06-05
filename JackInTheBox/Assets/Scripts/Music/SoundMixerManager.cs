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
    
    private float _standartVolume = Mathf.Log10(0.4f) * 20f;

    void Start()
    {
        if(!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", _standartVolume);
        //    sliderBGM.value = _standartVolume;
        } 
        else
        {
            LoadVolumeBGM();
        //    sliderBGM.value = PlayerPrefs.GetFloat("BGMValue");
        }
        
        if(!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", _standartVolume);
        //    sliderSFX.value = _standartVolume;
        }
        else
        {
            LoadVolumeSFX();
        //    sliderSFX.value = PlayerPrefs.GetFloat("SFXValue");
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
