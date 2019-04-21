using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade_SFX : MonoBehaviour
{
    public AudioClip[] spikeDam;
    public AudioSource spikeDamSource;

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        int randomIndex = Random.Range(0, spikeDam.Length - 1);
        spikeDamSource.clip = spikeDam[randomIndex];
        spikeDamSource.Play();
    }
}
