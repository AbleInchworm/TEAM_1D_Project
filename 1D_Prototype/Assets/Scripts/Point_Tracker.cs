using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Tracker : MonoBehaviour
{
    //preserve the beans between levels by telling the player how many to gain after exiting each level; 
    public int beansFromLevel;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Tracker");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
