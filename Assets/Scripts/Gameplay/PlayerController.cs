using System;
using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpStrength = 7f;
    [SerializeField] private float _extraGravity = 700f;
    [SerializeField] private float _gravityDelay = 0.2f;

    private float _timeInAir;

    private Rigidbody2D _rigidBody;
    private Movement _movement;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _rigidBody = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
       // GatherInput();
       // Movement();
        Jump();
        HandleSpriteFlip();
        GravityDelay();
    }

    private void FixedUpdate()
    {
        ApplyExtraGravity();
    }

    public bool IsFacingRight()
    {
        return transform.eulerAngles.y == 0;
    }

    private bool CheckGround()
    {
        Collider2D isGrounded = Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0f, _groundLayer);
        return isGrounded;
    }

    private void Jump()
    {
       // if (!_input.Jump) return;

        if (CheckGround())
        {
            _rigidBody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        }
    }

    private void GravityDelay()
    {
        if (!CheckGround())
        {
            _timeInAir += Time.deltaTime;
        }
        else
        {
            _timeInAir = 0f;
        }
    }

    private void ApplyExtraGravity()
    {
        if (_timeInAir > _gravityDelay)
        {
            var forceVector = new Vector2(0f, -_extraGravity * Time.deltaTime);
            _rigidBody.AddForce(forceVector);
        }
    }

    private void HandleSpriteFlip()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
    }
}