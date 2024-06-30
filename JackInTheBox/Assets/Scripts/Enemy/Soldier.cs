using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    //Moviment

    [SerializeField] private float _aceleration = 0.5f;
    //[SerializeField] private float _maxSpeed = 2.0f;
    private int _side = 1;

    [SerializeField] Animator _animator;

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
        _animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        _animator.speed = 1f;
    }

    void Start()
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
        if (_side == 1)
        {
            _rb.velocity = Vector3.right * _aceleration;
        }
        else if (_side == -1)
        {
            _rb.velocity = Vector3.left * _aceleration;
        }
            //_rb.AddForce(transform.forward * _aceleration, ForceMode.Force);

            // if (_rb.velocity.magnitude >= _maxSpeed)
            // {
            //     _rb.velocity = _rb.velocity.normalized * _maxSpeed;
            // }
    }

    //Collisions

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_isDead)
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
        ChangeSide();
        transform.rotation = Quaternion.Euler(_newRotation);
    }

    private void ChangeSide()
    {
        if (_side == 1)
            _side = -1;
        else
            _side = 1;
    }

    //State Loops

    void deathLoop()
    {
        _rb.isKinematic = true;
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