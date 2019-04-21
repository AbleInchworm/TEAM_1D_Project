using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour {
    
    public Player_Movement player;
    public ParticleSystem spiked;

    void Awake()
    {
        //player = Player_Movement.instance;
        player = GameObject.Find("Player_Controller").GetComponent<Player_Movement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player_Controller")
        {
            
            
            if (player.isDead == false)
            {
                spiked.Play();               
                player.isDead = true;
                player.KillPlayer();
            }
        }       
    }
}
