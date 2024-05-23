using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Movement

    [SerializeField] private float _aceleration = 20.0f;
    [SerializeField] private float _maxSpeed = 2.0f;

    [SerializeField] private float _jumpForce = 10.0f;
    private bool _doubleJumped;
    private bool _isGrounded;
    private bool _wallBounced;

    //Health

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth = 10;

    //Input Touch Actions

    private PlayerInput _playerInput;

    private InputAction _touchPressAction;

    private InputAction _swipeAction;

    //Physics

    private Rigidbody _rb;

    void Awake()
    {
        //TouchActions Reference

        _playerInput = GetComponent<PlayerInput>();

        _touchPressAction = _playerInput.actions.FindAction("Jump");
        _swipeAction = _playerInput.actions.FindAction("Swipe");

        //RigidBody Reference

        _rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
    }

    void FixedUpdate()
    {
        movementRun();
    }

    //Collisions

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.Rotate(Vector3.up * 180f);

            if(!_isGrounded && _wallBounced)
            {
                wallBounce();

            }
        }

        if (collision.gameObject.tag == "Plataform")
        {
            _isGrounded = true;
            _doubleJumped = true;
            _wallBounced = true;
        }
    }

    //Movement

    void movementRun()
    {
        _rb.AddForce(transform.forward * _aceleration, ForceMode.Force);

        if (_rb.velocity.magnitude >= _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }

    private void basicJump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }

    private void dashSide() 
    {
        
    }

    private void dashDown() 
    {
    
    }

    private void wallBounce() 
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    //Health

    public void takeDamage(int damageAmmount)
    {
        _currentHealth -= damageAmmount;
    }

    void healPlayer(int healAmmount)
    {
        _currentHealth += healAmmount;
    }

    //Touch Actions

    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
        _swipeAction.performed += SwipePerformed;
    }

    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;

    }

        //Press (Jump)

    private void TouchPressed(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            basicJump();
        }
        else if (!_isGrounded && _doubleJumped)
        {
            basicJump();
            _doubleJumped = false;
        }
    }
        //Swipe (Dashes)

    private void SwipePerformed(InputAction.CallbackContext context) 
    {
        Vector2 swipeDelta = context.ReadValue<Vector2>();

            // Swipe up (PlaceHolder)

        if (swipeDelta.y > Mathf.Abs(swipeDelta.x))
        {
            //Maybe Special
        }

            // Swipe down (Dash Down)

        else if (swipeDelta.y < -Mathf.Abs(swipeDelta.x))
        {

        }

            // Swipe right (Dash Right)

        else if (swipeDelta.x > Mathf.Abs(swipeDelta.y))
        {
            // Implementar ação para swipe para a direita, se necessário
        }

            // Swipe left (Dash Left)

        else if (swipeDelta.x < -Mathf.Abs(swipeDelta.y))
        {
            // Implementar ação para swipe para a esquerda, se necessário
        }
    }
}