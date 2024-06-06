using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static int _pointScore;

    [SerializeField] private List<GameObject> roomsList;

    void Awake() 
    {
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
        int randomIndex = Random.Range(0, roomsList.Count);

        GameObject randomRoom = roomsList[randomIndex];

        randomRoom.SetActive(true);
    }

    //Scenes Manager

    public void loadGameOver() 
    {
        SceneManager.LoadScene("3GameOver");
    }
}
