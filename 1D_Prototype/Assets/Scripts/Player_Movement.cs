﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {

    public static Player_Movement instance;

    // external scripts
    KillArea killArea;
    Exploding_Corpse corpseExplode;
    public Animator playerAnim;

    // player animator  
    public Animator anim;

    // Player states
    
    public bool isBurnt;
    [HideInInspector]
    public bool isDead;
    private bool isGrounded;
    private bool isOnCorpse;
    private bool isOnFire;
    private bool bouncing;
    private bool isInAir;



    [Header("Player_Movement")]
    public float moveSpeed;
    private float newMoveSpeed;
    public float crouchSpeedModifier = 2;
    private float moveInput;
    public bool isCrouching;

    [Header("Player_Jump")]
    public float jumpHeight;
    private float jumpTimeCounter;
    public float jumpHoldTime;
    private bool isJumping;
    private int extraJumps;
    public int extraJumpValue;

    [Header("Corpse_Bounce")]
    public float bounceForce;
    [HideInInspector]
    public float bounceJumpForce;
   
    [Header("On_Respawn")]
    public Transform respawnHere;

    [Header("Burning")]
    private float burnTime;
    public float maxBurnTime;
    private Vector3 timerLocation;

    [Header("Corpse_Spawn")]
    
    public GameObject targetClonePrefab;
    public GameObject clonedPrefab;
    
    public GameObject fireTimer;
    public Text fireTimerText;
    public int corpseLimit = 1;
    public Vector2 spawnCorpseHere;
    List<GameObject> corpses = new List<GameObject>();

    private Rigidbody2D rb2d;
    
    [HideInInspector]
    public Transform feetPos;
    [HideInInspector]
    public float checkRadius;
    [HideInInspector]
    public LayerMask whatIsGround;
    [HideInInspector]
    public LayerMask whatIsCorpse;
    [HideInInspector]
    public LayerMask whatIsFire;

    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {      
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        extraJumps = extraJumpValue;
        burnTime = maxBurnTime;
        fireTimerText = fireTimer.GetComponent<Text>();
        fireTimerText.text = burnTime.ToString();
        newMoveSpeed = moveSpeed;


    }

    void FixedUpdate()
    {
        // get the input of the A & D keys and apply motion to character        
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * newMoveSpeed, rb2d.velocity.y);
        
        if (bouncing == true)
        {
            corpseBounce();
            bouncing = false;
        }

        corpseJump();
    }

    void Update()
    {
        Debug.Log(isGrounded);

        PlayerCrouch();

        PlayerMovement();

        PlayerStateCheck();

        PlayerJump();

        HandleLayers();

        Suicide();

        FireCheck();      
    }

    public void PlayerStateCheck()
    {
       
        // reset double jump value
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
            isInAir = false;
        }

        // triggers the SuperJump function to be called in the fixed update
        if (isOnCorpse == true)
        {
            bouncing = true;
        }

        if (isOnFire)
        {
            isBurnt = true;
        }

        if (isJumping)
        {
            isInAir = true;
        }

        if (!isInAir)
        {
            playerAnim.SetBool("Player_Land", true);
        }
        else
        {
            playerAnim.SetBool("Player_Land", false);
        }
     
    }

    public void PlayerMovement()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isOnCorpse = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsCorpse);
        isOnFire = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsFire);

        playerAnim.SetFloat("Horizontal_Input", Mathf.Abs(moveInput)); // take the horizontal input, keep it between 0 and 1, then send it to the animator

        // if character is moving right, do nothing. if he is moving left, rotate sprites 180 degrees
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // the 180 in the vector3 refers to the rotation of the charcter (flips the sprint)
        }

    }

    public void PlayerCrouch()
    {

        if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
            newMoveSpeed = moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;

            if (isCrouching == true)
            {
                newMoveSpeed = moveSpeed / crouchSpeedModifier;
            }
        }
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            isJumping = true;           
            jumpTimeCounter = jumpHoldTime;
            rb2d.velocity += Vector2.up * jumpHeight;
            extraJumps--;
        }
        else if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) && extraJumps == 0)
        {           
            rb2d.velocity += Vector2.up * jumpHeight;          
        }

        // jump force increases the longer jump is held
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            playerAnim.SetTrigger("Jump");

            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;               
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            playerAnim.ResetTrigger("Jump");
        }
    }


    // bounces the character when he is on his corpse 
    void corpseBounce()
    {
        rb2d.velocity = Vector2.zero; //resetbounce force to stop stacking
        rb2d.velocity = Vector2.up * bounceForce; //apply up force relative to the bounce force float
    }

    void corpseJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnCorpse == true)
        {
            bounceForce = bounceForce + bounceJumpForce; // pressing jump while making contact with corpse will add an additional force
            bounceForce = bounceForce - bounceJumpForce; 
        }
    }

    public void KillPlayer()
    {
        isDead = false;
        isBurnt = false;
        transform.position = respawnHere.transform.position;
        burnTime = maxBurnTime;
    }

    public void SpawnCorpse()
    {
        spawnCorpseHere = gameObject.transform.position; // sets the location where the corpse prefab should spwan

        clonedPrefab = Instantiate(targetClonePrefab, spawnCorpseHere, transform.rotation); // sets the desired clone to the spcified game object and location
        corpses.Add(clonedPrefab); // add that clone to a list to keep track of
        while (corpses.Count > corpseLimit)
        {
            if (corpses[0] != null)
                Destroy(corpses[0].gameObject);
            corpses.RemoveAt(0);
        }

        KillPlayer();
    }

    public void Suicide()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnCorpse();
        }
    }

    public void StartBurnTime()
    {
        burnTime -= Time.deltaTime;
        fireTimerText.text = burnTime.ToString();

        if (burnTime < 0)
        {
            SpawnCorpse();
            burnTime = maxBurnTime;
            //fireTimerText = null;
        }
    }
    public void FireCheck()
    {        
        if (isBurnt == true)
        {           
            StartBurnTime();
        }
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            playerAnim.SetLayerWeight(1, 1);
        }
        else
        {
            playerAnim.SetLayerWeight(1, 0);
        }
    }



}

