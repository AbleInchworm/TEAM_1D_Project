using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    private Player_Movement player;
    public AudioSource fireSFX;

    void Awake()
    {
        //player = Player_Movement.instance;
        player = GameObject.Find("Player_Controller").GetComponent<Player_Movement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        fireSFX.Play();
        player.isBurnt = true;   
        
    }

}
