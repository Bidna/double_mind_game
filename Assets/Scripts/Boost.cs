using System;
using UnityEngine;

public class Boost : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = FindObjectOfType<Player>();
        if (!(Math.Abs(player.speed - 4) < 0.01)) return;
        player.StartCoroutine(player.BoostTimer());
        Destroy(this.gameObject);
    }
    
}
