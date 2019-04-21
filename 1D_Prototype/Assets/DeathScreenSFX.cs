using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenSFX : MonoBehaviour
{
    public static DeathScreenSFX instance;

    public AudioSource aSource;
    
    public void playDScreenSFX()
    {
        aSource.Play();
    }       
}
