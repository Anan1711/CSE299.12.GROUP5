﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Variable for referencing Character Controller script.
    public CharacterController2D controller;

    public Animator animator;

    // Variable for controlling the speed of the movement.
    public float runSpeed = 100f;

    float horizontalMove = 0f;
    bool Jump = false;
    bool crouch = false;

    // This function gets input from the player.
    // Update is called once per frame.
    void Update()
    {
        // GetAxisRaw function is for getting input from the player to where to move.
        // horizontalMove can be 1 for going right or -1 for going left.
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Function for transitioning from idle to running animation.
        // Mathf.Abs takes the absolute value of the horizontalMove so that value is always positive.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // If we are jumping.
        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;

            // Function for transitioning to jumping animation.
            animator.SetBool("IsJumping", true);
        }

        // If we are crouching.
        // We want to stop crouching when we release the button.
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        




    }

    // functions can be public as well.
    // When to stop jumping.
    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
    }

    // Function for Crouching/not crouching.
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
        
        
    }

    // This function is called a fixed amount of time. Not like 'Update' method which is called once after the computer draws a frame.
    void FixedUpdate()
    {
        // Moves the character
        // Time.fixedDeltaTime is the time elapsed when this function was last called. Ensures we move the same amount no matter how often FixedUpdate is called.
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, Jump);

        

        
        

        // To stop jumping.
        Jump = false;
    }
}
