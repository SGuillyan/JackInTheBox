using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsMenu;

    private GameManager _gameManager;

    void Awake()
    {
        creditsMenu.SetActive(false);
    }

    void Start()
    {
        _gameManager = GameManager.instance;
    }

    public void StartGame()
    {
        _gameManager.restartRoomLoop();
        SceneManager.LoadScene("2Game");
        Time.timeScale = 1;
    }

    public void CreditsMenu()
    {
        creditsMenu.SetActive(true);
    }

    public void CloseCreditsMenu()
    {
        creditsMenu.SetActive(false);
    }
}
