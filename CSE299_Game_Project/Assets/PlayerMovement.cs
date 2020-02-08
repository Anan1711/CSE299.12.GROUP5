using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //referencing CharacterController2D controller

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;



    void Update()
    //apply that input to our player
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // movement horizontal or X axis
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    void FixedUpdate()
        //apply that input to our chararter
    {
        //referencing CharacterController2D
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //Time.fixedDeltaTime is amount of time elapsed since last func called
        jump = false;
    }
}


