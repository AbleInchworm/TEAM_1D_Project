using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{

    public Transform[] moveSpots;
    private int randomSpot;

    private bool isHostile;
    public Player_Movement player;
   

    private float waitTime;
    public float startwaitTime;
    public float moveSpeed;

    //public float stopDis;

    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startwaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        isHostile = false;
        player = GameObject.Find("Player_Controller").GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }

    void EnemyPatrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startwaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        isHostile = true;
        print("Im_Hostile");

        //if (collision.gameObject.name == "Player")
        //{
            
        //    isHostile = true;
        //    print("Im_Hostile");
        //}
    }
}
