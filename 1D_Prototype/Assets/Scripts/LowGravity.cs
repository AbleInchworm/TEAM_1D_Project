using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravity : MonoBehaviour
{
    public float grav;

    //lower the gravity when touched to make the fall longer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Player_Movement>().GetComponent<Rigidbody2D>().gravityScale = grav;
        Destroy(gameObject);
    }
}
