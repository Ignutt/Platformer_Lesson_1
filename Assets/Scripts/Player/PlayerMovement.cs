using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    private float _move = 0;
    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        _move = Input.GetAxis("Horizontal");
        
        _animator.SetBool("isWalking", _move != 0);
        
        if (_move > 0 && transform.localScale.x < 0 || _move < 0 && transform.localScale.x > 0) Flip();
        
        _rigidbody.velocity = new Vector2(_move * speed, _rigidbody.velocity.y);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
