using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Player : MonoBehaviour
{
    [SerializeField]
    private int lives;
    public int Lives
    {
        get => lives;
        set { 
            lives = value;
            healthBar.SetHp(value);
            if (lives <= 0)
            {
                StartCoroutine(RestartLevel());
            }
        }
    }

    private IEnumerator RestartLevel()
    {
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public float speed;
    public float jumpForce;
    public LayerMask ground;
    public GameObject deathScreen;
    
    private CamShake shaking;
    private HealthBar healthBar;
    private bool isGrounded;
    private float runDirection;
    
    private CharState State
    {
        set => animators.ForEach((x) => x.SetInteger("State",(int) value));
    }

    private Rigidbody2D rb;
    private List<Animator> animators;
    private List<SpriteRenderer> sprites;
    
    private bool mustJump;
    private float jumpCooldown;

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
        shaking = FindObjectOfType<CamShake>();
        rb = GetComponent<Rigidbody2D>();
        animators = new List<Animator>(GetComponentsInChildren<Animator>(true));
        sprites = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>(true));
    }
    
    private void FixedUpdate()
    {
        CheckGround();
    }
    
    private void Update()
    {
        jumpCooldown -= Time.deltaTime;
        if(isGrounded) 
            State = CharState.Idle;
        if (Input.GetButton("Horizontal")) 
            SetRunDirection(Input.GetAxis("Horizontal"));
        Run(runDirection);
        if (Input.GetButtonDown("Jump")) SetJump();
        if (mustJump) Jump();
    }

    public void SetRunDirection(float newRunDirection) => runDirection = newRunDirection;
    public void SetJump()
    {
        if (!isGrounded || jumpCooldown >= 0)
            return;
        mustJump = true;
    }

    private void Run(float runDirection)
    {
        if (Math.Abs(runDirection) < 0.01f) return;
        var direction = transform.right *  runDirection;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprites.ForEach((x)=>x.flipX = direction.x < 0.0F);
        if(isGrounded) State = CharState.Run;
        SetRunDirection(0);

    }
    private void Jump()
    {
        State = CharState.Jump;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        mustJump = false;
        jumpCooldown = 0.1f;
    }
    
    public void ReceiveDamage()
    {
        shaking.Shake();
        sprites.ForEach((x)=>x.color = Color.red);
        Lives--;
        rb.velocity = Vector3.zero;
        Jump();
        Invoke(nameof(SetWhiteSprite), 0.3f);
    }
    
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.25f, 0.05f), 0,ground).Length > 0;
        if (!isGrounded) State = CharState.Jump;
    }

    private void SetWhiteSprite() => sprites.ForEach((x)=>x.color = Color.white);

    public IEnumerator BoostTimer()
    {
        speed *= 1.5F;
        yield return new WaitForSeconds(5);
        speed /= 1.5F;
    }
}


public enum CharState
{
    Idle,
    Run, 
    Jump
}