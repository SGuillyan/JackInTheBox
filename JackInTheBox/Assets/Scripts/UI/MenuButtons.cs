using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    
    private SFXPlayer _sfxPlayer;
    [SerializeField] AudioClip btnClickSoundClip;

    void Awake()
    {
        settingsMenu.SetActive(false);
    }

    void Start()
    {
        _sfxPlayer = SFXPlayer.instance;
    }

    private void ButtonClicked()
    {
        _sfxPlayer.PlaySFX(btnClickSoundClip, transform, 1f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("2Game");
        Time.timeScale = 1;        
        ButtonClicked();
    }

    public void PauseGame()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
        ButtonClicked();
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
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
}
