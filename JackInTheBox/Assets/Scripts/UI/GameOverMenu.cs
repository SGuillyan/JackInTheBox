using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("2Game");
        Time.timeScale = 1;        
    //    ButtonClicked();
    }

    public void QuitGame()
    {
        Debug.Log("Fechar programa");
        Application.Quit();
    }
}
