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
        playerControler = FindObjectOfType<Player_Movement>().gameObject;
        visible = textImage1.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerControler. transform.position, transform.position);

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

        if (dist > 5)
            visible.enabled = false;
        else
            visible.enabled = true;        
    }
}
