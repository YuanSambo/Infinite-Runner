using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (MovementSpeed * Time.deltaTime));
    }
}
