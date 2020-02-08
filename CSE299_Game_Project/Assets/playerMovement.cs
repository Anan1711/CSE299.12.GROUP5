using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 100f;
    float horizontalMove = 0f;
    bool Jump = false;
    bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    }

    void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime ,crouch,Jump);
        Jump = false;
    }
}
