using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animation camShake;
    public void Shake()
    { 
        camShake.Play("shake");
    }
}
