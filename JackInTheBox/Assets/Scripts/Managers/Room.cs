using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;

    public GameManager gameManager;

    void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnEnable()
    {
        transform.position = new Vector3(0, 4.7f, 0);
    }

    void FixedUpdate()
    {
        verticalMovement();
        verifyPosition();
    }

    void OnDisable() 
    {
        transform.position = new Vector3(4, 0, 0);        
    }

    void verticalMovement()
    {
        float displacement = _speed * Time.fixedDeltaTime;

        transform.Translate(Vector3.down * displacement);
    }

    void verifyPosition() 
    {
        if(transform.position.y <= -4.7) 
        {
            gameManager.roomRandomLoop();
            deactivateRoom();
        }
    }

    void deactivateRoom() 
    {
        gameObject.SetActive(false);
    }
}
