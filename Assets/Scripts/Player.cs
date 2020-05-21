﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded = false;


    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }
   
    private void Run()
    {
        Vector3 direction = transform.right *  Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F; 
    }
    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        Debug.Log(colliders.Length);
        isGrounded = colliders.Length > 1;
    }
}
