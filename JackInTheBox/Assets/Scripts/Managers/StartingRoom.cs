using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.instance;
    }

    void FixedUpdate()
    {
        if (_gameManager.PlayerStarted)
        {
            verticalMovement();
            verifyPosition();
        }
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
            _gameManager.roomRandomLoop();
        }
    }

    void deactivateRoom()
    {
        transform.position = new Vector3(4, 0, 0);
        gameObject.SetActive(false);
    }
}
