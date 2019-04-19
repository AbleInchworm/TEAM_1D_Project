using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpseShow : MonoBehaviour
{
    public int visibleDelay;
    private SpriteRenderer visible;

    private void Start()
    {
        visible = GetComponent<SpriteRenderer>();
        visible.enabled = false;
    }

    private void FixedUpdate()
    {
        if (visibleDelay > 0)
            visibleDelay -= 1;
        else
            visible.enabled = true;
    }
}
