using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] private float _aceleration = 20.0f;
    [SerializeField] private float _maxSpeed = 2.0f;

    private Player _player;

    private bool _isDashing;

    private Rigidbody _rb;

    void Awake()
    {


        GameObject playerGameObject = GameObject.Find("Player");
        if (playerGameObject != null)
        {
            _player = playerGameObject.GetComponent<Player>();
        }

        _rb = GetComponent<Rigidbody>();

        _isDashing = false;

    }

    void FixedUpdate()
    {
        movementRun();
    }

    void movementRun()
    {
        if (!_isDashing)
        {
            _rb.AddForce(transform.forward * _aceleration, ForceMode.Force);

            if (_rb.velocity.magnitude >= _maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * _maxSpeed;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player.takeDamage(5);
        }
        if (other.gameObject.tag == "PlataformWall")
        {
            transform.Rotate(Vector3.up * 180f);
        }
    }
}
