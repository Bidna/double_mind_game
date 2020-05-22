﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded = false;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State");}
        set { animator.SetInteger("State",(int) value); }
    }

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
        if(isGrounded) State = CharState.Idle;
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }
   
    private void Run()
    {
        Vector3 direction = transform.right *  Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
        if(isGrounded) State = CharState.Run;
    }
    private void Jump()
    {
        State = CharState.Jump;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    public override void ReceiveDamage()
    {
        lives--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up  * 8.0F, ForceMode2D.Impulse);
        Debug.Log(lives);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        Debug.Log(colliders.Length);
        isGrounded = colliders.Length > 1;
        if (!isGrounded) State = CharState.Jump;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Unit unit = collider.gameObject.GetComponent<Unit>();
        //if (unit) ReceiveDamage();
    }
}


public enum CharState
{
    Idle,
    Run, 
    Jump
}