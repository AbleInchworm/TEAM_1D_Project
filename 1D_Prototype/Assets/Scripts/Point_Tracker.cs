using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Tracker : MonoBehaviour
{
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
