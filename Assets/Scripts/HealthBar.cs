using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[3];
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.Lives)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
