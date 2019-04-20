using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFalling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<Player_Movement>().isGrounded = false;
        FindObjectOfType<Player_Movement>().playerAnim.SetTrigger("Jump");
    }
}
