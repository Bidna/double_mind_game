using UnityEngine;
using System.Linq;
public class Monster : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    public AudioSource kill;

    private Vector3 direction;

    protected void Start()
    {
        direction = transform.right;
    }
    
    protected void Update()
    {
        Move();
    }
    
    protected void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();

        if(collider.gameObject.tag == "Obstacle" && Mathf.Abs(collider.transform.position.x - transform.position.x) < 0.5f)
        {
            ReceiveDamage();
        }
        if (player != null)
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 0.5f)
            {
                player.Score += 10;
                kill.Play();
                ReceiveDamage();
            }
            else player.ReceiveDamage();
        }
    }

   
    private void Move()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right*direction.x * 0.7F, 0.2F);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Player>())) direction *= -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void ReceiveDamage()
    {
        Destroy(gameObject);
    }
}
