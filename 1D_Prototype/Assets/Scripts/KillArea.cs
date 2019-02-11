using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour {

    private Player_Movement player;

    void Awake()
    {
        player = Player_Movement.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.isDead == false)
        {
            player.isDead = true;
            player.KillPlayer();

        }
    }    
}
