using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FS_State_Stone : MonoBehaviour
{
    Player_Movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_Controller").GetComponent<Player_Movement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.isOnStone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.isOnStone = false;
    }    
}
