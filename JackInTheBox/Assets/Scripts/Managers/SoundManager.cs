using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider sliderBGM;

    void Start()
    {
        if(!PlayerPrefs.HasKey("volumeBGM"))
        {
            PlayerPrefs.SetFloat("volumeBGM", 0.5f);
            SaveVolume();
        }
        else
            LoadVolume();
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = sliderBGM.value;
        SaveVolume();
    }

    private void LoadVolume()
    {
        sliderBGM.value = PlayerPrefs.GetFloat("volumeBGM");
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("volumeBGM", sliderBGM.value);
    }
}
