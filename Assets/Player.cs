using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public float FallMultiplier = 2.5f;
    public float GroundCheckHeight;
    public LayerMask GroundLayer;
    public bool Grounded;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private BoxCollider2D _boxCollider2D;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (MovementSpeed * Time.deltaTime));



        if (Input.GetMouseButtonDown(0) && Grounded)
        {
           Jump();
        }
        
    }


    private void FixedUpdate()
    {

        Grounded = IsGrounded();
        // Better Jump
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.gravityScale = FallMultiplier;
        }
      
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up*JumpForce,ForceMode2D.Impulse);
    }
    
    private bool IsGrounded()
    {
        var bounds = _boxCollider2D.bounds;
        RaycastHit2D raycastHit = Physics2D.Raycast(bounds.center, Vector2.down, bounds.extents.y+GroundCheckHeight,GroundLayer);
        return raycastHit.collider!=null;
    }
}
