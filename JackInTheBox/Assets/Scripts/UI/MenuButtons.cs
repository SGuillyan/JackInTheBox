using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] Slider sliderBGM;

    void Awake()
    {
        settingsMenu.SetActive(false);
    }

    private void ButtonClicked()
    {
        //SoundManager.instance.PlaySFX(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("2Game");
        ButtonClicked();
    }

    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
        ButtonClicked();
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        ButtonClicked();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("1MainMenu");
        ButtonClicked();
    }

    public void QuitGame()
    {
        Debug.Log("Fechar programa");
        Application.Quit();
    }

    public void SetVolume(float volume)
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
