using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    private Player_Movement player;

    void Awake()
    {
        player = Player_Movement.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("burning");
        player.isBurnt = true;     
    }

}
