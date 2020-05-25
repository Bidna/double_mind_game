using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player && player.Lives < 3)
        {
            
            player.Lives++;
            Destroy(gameObject);
        }
    }
}
