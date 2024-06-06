using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    void Awake()
    {
        settingsMenu.SetActive(false);
    }

    private void ButtonClicked()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("2Game");
        Time.timeScale = 1;        
    //    ButtonClicked();
    }

    public void PauseGame()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    //    ButtonClicked();
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    //    ButtonClicked();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("1MainMenu");
    //    ButtonClicked();
    }

    public void QuitGame()
    {
        Debug.Log("Fechar programa");
        Application.Quit();
    }
}
