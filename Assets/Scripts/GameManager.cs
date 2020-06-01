using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<bool> OnWorldChange ;
    private bool normalWorld = true;
    public bool NormalWorld => normalWorld;
    public void ChangeWorld()
    {
        normalWorld = !normalWorld;
        OnWorldChange?.Invoke(normalWorld);
    }
}
