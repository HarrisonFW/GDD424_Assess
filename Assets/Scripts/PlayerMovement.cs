﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Code provided for this script, PlayerCamera and moveCamera from Dave / GameDevelopment on YouTube https://youtu.be/f473C43s8nE

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    
    


    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJumpAgain;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;      

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJumpAgain = true;
    }

    private void Update()
    {
        //ground check to check the player is indeed touching the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.extents.y + 0.3f, whatIsGround);


        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput() // inputs handeled here
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(KeyCode.Space) && readyToJumpAgain )
        {
            Debug.Log("Spacebar is being pressed");
            readyToJumpAgain = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate the players moving direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
       
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVelocity.x, rb.velocity.y, limitVelocity.z);
        }
    }

    private void Jump() // really bootleg jumping code, if the player jumped off a tall building, they coudl jump again in the air because of a "jump timer" running out
    {
        Debug.Log("Jump force applied:  " + jumpForce);
        Debug.Log("Current velocity after jump:  " + rb.velocity);
        //reset the Y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJumpAgain = true;
    }

}
