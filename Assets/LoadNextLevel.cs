using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Player>().Score += 100;
            FindObjectOfType<LevelManager>().LoadLevel(FindObjectOfType<LevelManager>().currentLevelIndex +1);
            Resources.FindObjectsOfTypeAll<LoginScreen>()[0].SendData();
        }

    }
}
