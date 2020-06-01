using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        if (!player || player.Lives >= 3) return;
        player.Lives++;
        Destroy(gameObject);
    }
}