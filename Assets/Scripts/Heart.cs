using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]
    public AudioSource heal;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        if (!player || player.Lives >= 3) return;
        player.Lives++;
        Invoke("heal.Play()", 2f);
        Destroy(gameObject);
    }
}