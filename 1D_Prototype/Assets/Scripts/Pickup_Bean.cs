using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Bean : MonoBehaviour
{
    private float myScale;
    public float stepScale;
    private float maxScale;
    private float minScale;
    public float tick;
    bool isGrowing;

    public AudioSource beanPickUp;

    // Start is called before the first frame update
    void Start()
    {
        myScale = transform.localScale.x;
        maxScale = myScale + (stepScale * 3);
        minScale = myScale - (stepScale * 3);
        tick = 0;
        isGrowing = true;
        stepScale = (stepScale / 30);
    }

    // Update is called once per frame
    void Update()
    {
        //animate the bean by having it expand and shrink and glow
        if (isGrowing == true)
        {
            transform.localScale += new Vector3(stepScale, stepScale, 0);
            myScale = transform.localScale.x;
            gameObject.GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 55f / 255f);
            tick += 1;
            if (tick == 30)
            {
                isGrowing = false;
            }
        }
        if (isGrowing == false)
        {
            transform.localScale -= new Vector3(stepScale, stepScale, 0);
            myScale = transform.localScale.x;
            gameObject.GetComponent<Renderer>().material.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            tick -= 1;
            if (tick == 0)
            {
                isGrowing = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //colect the bean and add it to the count
        beanPickUp.Play();
        FindObjectOfType<Player_Movement>().myBeans += 1;
        Destroy(gameObject);
    }
}
