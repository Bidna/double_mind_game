using UnityEngine;

internal class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<Player>();
        player.Lives -= player.Lives;
        Destroy(gameObject);
    }
}