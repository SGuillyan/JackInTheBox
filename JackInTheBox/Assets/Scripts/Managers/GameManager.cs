using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static int _pointScore;

    public bool PlayerStarted;

    [SerializeField] private List<GameObject> roomsList;

    void Awake() 
    {
        PlayerStarted = false;

        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);        
        }
    }

    //Random Room Loop

    public void roomRandomLoop() 
    {
        bool foundInactiveRoom = false;
        int randomIndex = 0;

        while(!foundInactiveRoom)
        {
            randomIndex = Random.Range(0, roomsList.Count);
            GameObject randomRoom = roomsList[randomIndex];

            if (!randomRoom.activeSelf) 
            {
                randomRoom.SetActive(true);
                foundInactiveRoom = true;
            }
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

    //Scenes Manager

    public void loadGameOver() 
    {
        SceneManager.LoadScene("3GameOver");
    }
}
