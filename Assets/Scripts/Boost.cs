using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = FindObjectOfType<Player>();
        player.StartCoroutine("boostTimer");
        Destroy(this.gameObject);
    }
    
}
