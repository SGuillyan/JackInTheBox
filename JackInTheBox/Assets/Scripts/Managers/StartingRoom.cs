using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;

    public GameManager gameManager;

    void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Start()
    {
    }

    void FixedUpdate()
    {
        verticalMovement();
        verifyPosition();
    }

    void verticalMovement()
    {
        float displacement = _speed * Time.fixedDeltaTime;

        transform.Translate(Vector3.down * displacement);
    }

    void verifyPosition()
    {
        if (transform.position.y <= -4.7)
        {
            deactivateRoom();
            gameManager.roomRandomLoop();
        }
    }

    void deactivateRoom()
    {
        transform.position = new Vector3(4, 0, 0);
        gameObject.SetActive(false);
    }
}
