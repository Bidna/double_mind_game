using System;
using System.Collections;
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
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [SerializeField]
    private CamShake shaking;
    private HealthBar healthBar;
    [SerializeField]
    public float speed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded;
    private float runDirection;
    
    private CharState State
    {
        get => (CharState)animator.GetInteger("State");
        set => animator.SetInteger("State",(int) value);
    }

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    [SerializeField] private GameObject deathScreen;
    private bool mustJump;
    private float jumpCooldown;

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

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
        if (Input.GetButtonDown("Jump") || mustJump) Jump();
    }

    public void SetRunDirection(float newRunDirection) => runDirection = newRunDirection;
    public void SetJump() => mustJump = true;

    private void Run(float runDirection)
    {
        if (Math.Abs(runDirection) < 0.01f) return;
        var direction = transform.right *  runDirection;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
        if(isGrounded) State = CharState.Run;
        SetRunDirection(0);

    }
    private void Jump()
    {
        if (!isGrounded || jumpCooldown > 0)
            return;
        State = CharState.Jump;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        mustJump = false;
        jumpCooldown = 0.1f;
    }
    
    public void ReceiveDamage()
    {
        shaking.Shake();
        sprite.color = Color.red;
        Lives--;
        rb.velocity = Vector3.zero;
        Jump();
        Invoke(nameof(SetWhiteSprite), 0.3f);
    }
    
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircleAll(transform.position, 0.3F).Length > 1;
        if (!isGrounded) State = CharState.Jump;
    }

    private void SetWhiteSprite() => sprite.color = Color.white;

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