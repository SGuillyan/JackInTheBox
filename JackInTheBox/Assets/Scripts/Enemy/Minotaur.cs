using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    //Moviment

    [SerializeField] private float _aceleration = 20.0f;
    [SerializeField] private float _maxSpeed = 2.0f;

    private bool _isCharging;
    private bool _isDead;

    //References

    private Rigidbody _rb;
    private Player _player;
    private BoxCollider _boxCollider;

    void Awake()
    {
        GameObject playerGameObject = GameObject.Find("Player");

        if (playerGameObject != null)
        {
            _player = playerGameObject.GetComponent<Player>();
        }

        _rb = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    void Start() 
    {
        startLoop();
    }

    void OnEnable() 
    {
        startLoop();
    }

    void FixedUpdate()
    {
        movementRun();
    }

    //Moviment

    void movementRun()
    {
        if (!_isCharging && !_isDead)
        {
            _rb.AddForce(transform.forward * _aceleration, ForceMode.Force);

            if (_rb.velocity.magnitude >= _maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * _maxSpeed;
            }

        }
    }

    //Collisions

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!_isDead) 
            {
                playerCollisionManager();
            }
        }
        if (other.gameObject.tag == "PlataformWall")
        {
            wallRotation();
        }
    }

    void playerCollisionManager() 
    {
        if (_player._isDashing) 
        {
            deathLoop();
        }
        else 
        {
            _player.takeDamage(3);
        }
        
    }

    //Interactions

    private void wallRotation() 
    {
        Vector3 _newRotation = transform.rotation.eulerAngles;
        _newRotation *= -1;
        transform.rotation = Quaternion.Euler(_newRotation);
    }

    //State Loops

    void deathLoop() 
    {
        _rb.isKinematic = false;
        _boxCollider.enabled = false;
        _isDead = true;
    }

    void startLoop() 
    {
        _rb.isKinematic = false;
        _boxCollider.enabled = true;
        _isDead = false;
        _isCharging = false;
    }
}