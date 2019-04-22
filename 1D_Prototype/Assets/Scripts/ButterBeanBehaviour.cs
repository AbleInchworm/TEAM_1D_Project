using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterBeanBehaviour : MonoBehaviour
{
    public GameObject textImage1;
    public GameObject playerControler;
    public float myScale;
    private SpriteRenderer visible;

    // Start is called before the first frame update
    void Start()
    {
        //find the player character to be able to calculate distance; use a "visible" var to switch the dialogue box off and on
        playerControler = FindObjectOfType<Player_Movement>().gameObject;
        visible = textImage1.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerControler. transform.position, transform.position);

        //face the player when talking to them by flipping the sprite
        if ((playerControler.transform.position.x) > (transform.position.x))
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -myScale;
            transform.localScale = newScale;
        }
        else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = myScale;
            transform.localScale = newScale;
        }

        //depending on the distance to the player, show or hide the dialogue box
        if (dist > 5)
            visible.enabled = false;
        else
            visible.enabled = true;        
    }
}
