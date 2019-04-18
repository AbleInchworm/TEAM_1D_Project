using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public float myScale;
    public float stepScale;
    SpriteRenderer visible;

    // Start is called before the first frame update
    void Start()
    {
        visible = GetComponent<SpriteRenderer>();
        visible.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((FindObjectOfType<Player_Movement>().isBurnt == true))
        {
            visible.enabled = true;
            transform.localScale += new Vector3(stepScale/30, stepScale/30, 0);
        }
        else
        {
            visible.enabled = false;
            transform.localScale = new Vector3(myScale, myScale, 0);
        }
    }
}
