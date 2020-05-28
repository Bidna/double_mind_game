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
                RestartLevel();
            }
        }
    }

    private static void RestartLevel()
    {
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

    private CharState State
    {
        get => (CharState)animator.GetInteger("State");
        set => animator.SetInteger("State",(int) value);
    }

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
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
        if(isGrounded) State = CharState.Idle;
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }
   
    private void Run()
    {
        var direction = transform.right *  Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
        if(isGrounded) State = CharState.Run;
        
    }
    private void Jump()
    {
        State = CharState.Jump;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    public void ReceiveDamage()
    {
        shaking.Shake();
        sprite.color = Color.red;
        Lives--;
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up  * 8.0F, ForceMode2D.Impulse);
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