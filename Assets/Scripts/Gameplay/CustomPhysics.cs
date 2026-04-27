using System;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpStrength = 7f;
    [SerializeField] private float extraGravity = 700f;
    [SerializeField] private float gravityDelay = 0.2f;
    
    public Vector2 GetVelocity =>  rb.linearVelocity; 
    public bool IsGrounded => CheckGround();
    
    private float _timeInAir;

    private void Update()
    {
        GravityDelay();
        
        Debug.Log("Is Grounded: " + IsGrounded);
    }

    private void FixedUpdate()
    {
        ApplyExtraGravity();
    }
    
    private bool CheckGround()
    {
        Collider2D isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0f, groundLayer);
        return isGrounded;
    }
    
    public void GravityDelay()
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
    
    public void Jump(bool isJumping)
    {
        if (!isJumping) return;

        if (CheckGround())
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }

    private void ApplyExtraGravity()
    {
        if (_timeInAir > gravityDelay)
        {
            var forceVector = new Vector2(0f, -extraGravity * Time.deltaTime);
            rb.AddForce(forceVector);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
    }
}
