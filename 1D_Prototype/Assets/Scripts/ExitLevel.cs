using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Point_Tracker>().beansFromLevel = FindObjectOfType<Player_Movement>().myBeans; ;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
