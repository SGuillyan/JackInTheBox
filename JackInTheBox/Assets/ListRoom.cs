using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListRoom : MonoBehaviour
{
    [SerializeField] public List<GameObject> roomsList;

    public void roomRandomLoop()
    {
        bool foundInactiveRoom = false;
        int randomIndex = 0;

        while (!foundInactiveRoom)
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
}
