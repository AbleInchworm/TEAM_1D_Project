using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{
    public AudioSource coinSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinSFX.Play();
        Destroy(gameObject);
    }
}
