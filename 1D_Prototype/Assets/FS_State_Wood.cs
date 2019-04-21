using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS_State_Wood : MonoBehaviour
{
    Player_Movement player;

    void Start()
    {
        player = GameObject.Find("Player_Controller").GetComponent<Player_Movement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.isOnWood = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isOnWood = false;
    }
}
