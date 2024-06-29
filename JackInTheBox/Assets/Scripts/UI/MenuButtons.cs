using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject creditsMenu;
    
    private SFXPlayer _sfxPlayer;
    [SerializeField] AudioClip btnClickSoundClip;
    
    private GameManager _gameManager;


    void Awake()
    {
        settingsMenu.SetActive(false);
        helpMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    void Start()
    {
        _sfxPlayer = SFXPlayer.instance;
        _gameManager = GameManager.instance;
    }

    private void ButtonClicked()
    {
        _sfxPlayer.PlaySFX(btnClickSoundClip, transform, 1f);
    }

    public void StartGame()
    {
        _gameManager.restartRoomLoop();
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
        helpMenu.SetActive(false);
        creditsMenu.SetActive(false);
        Time.timeScale = 1;
        ButtonClicked();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("1MainMenu");
        ButtonClicked();
    }

    public void HelpMenu()
    {
        helpMenu.SetActive(true);
        ButtonClicked();
    }

    public void CreditsMenu()
    {
        creditsMenu.SetActive(true);
        settingsMenu.SetActive(true);        
        ButtonClicked();        
    }
}
