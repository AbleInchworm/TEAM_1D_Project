using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySigil : MonoBehaviour
{
    public int selfDestruct;

    // Update is called once per frame
    void Update()
    {
        if (selfDestruct > 0)
            selfDestruct -= 1;
        else
            Destroy(gameObject);
    }
}
