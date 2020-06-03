using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<bool> OnWorldChange ;
    private bool normalWorld = true;
    public bool NormalWorld => normalWorld;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            ChangeWorld();
        }
    }

    public void ChangeWorld()
    {
        normalWorld = !normalWorld;
        OnWorldChange?.Invoke(normalWorld);
    }
}
