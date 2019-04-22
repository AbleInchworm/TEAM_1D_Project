using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    private float myScale;
    public float stepScale;
    private float maxScale;
    private float minScale;
    public float tick;
    bool isGrowing;

    public float spinSpeed;

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
        //animate the portal by having it expand/shrink and spin
        transform.Rotate(new Vector3(0, 0, spinSpeed));

        if (isGrowing == true)
        {
            transform.localScale += new Vector3(stepScale, stepScale, 0);
            myScale = transform.localScale.x;
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
            tick -= 1;
            if (tick == 0)
            {
                isGrowing = true;
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //set the Point Tracker's beans count to the player's bean count to preserve the amount of beans between levels
        FindObjectOfType<Point_Tracker>().beansFromLevel = FindObjectOfType<Player_Movement>().myBeans; ;

        //progreess through scenes by adding 1 to the scene index; if it's the last scene, end the game
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 5)
            Application.Quit();
        else
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
