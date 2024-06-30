using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static int _pointScore;

    public bool PlayerStarted;

    private ListRoom listRoom;

    void Awake()
    {
        PlayerStarted = false;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Certifique-se de que ListRoom está presente na cena e acessível.
        listRoom = FindObjectOfType<ListRoom>();

        if (listRoom == null)
        {
            Debug.LogError("ListRoom não encontrado na cena!");
        }
    }

    // Random Room Loop
    public void roomRandomLoop()
    {
        if (listRoom != null)
        {
            listRoom.roomRandomLoop();
        }
    }

    public void startRoomLoop()
    {
        PlayerStarted = true;
    }

    public void restartRoomLoop()
    {
        PlayerStarted = false;
    }

    // Scenes Manager
    public void loadGameOver()
    {
        SceneManager.LoadScene("3GameOver");
    }
}
