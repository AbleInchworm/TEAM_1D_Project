using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSaw : MonoBehaviour
{
    public float spinSpeed;
    float smooth = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, spinSpeed));
    }
}
