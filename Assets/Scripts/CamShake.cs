using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animation camShake;
    public void Shake()
    { 
        camShake.Play("shake");
    }
}
