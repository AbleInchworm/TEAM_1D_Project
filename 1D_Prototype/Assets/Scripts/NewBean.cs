﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBean : MonoBehaviour
{
    GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        //upon creation, set the player's respawn position to where the bean has been planted
        checkpoint = GameObject.Find("Start_Pos");
        checkpoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
