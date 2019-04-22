using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySigil : MonoBehaviour
{
    public int selfDestruct;

    // Update is called once per frame
    void Update()
    {
        //clean up after x frames as to not clutter the scene
        if (selfDestruct > 0)
            selfDestruct -= 1;
        else
            Destroy(gameObject);
    }
}
