using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;

    public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update() //get input from the player
	{
		// horizontal value 1, when goes right, value -1 when goes left

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // GetAxis - where to move the player 

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //Mathf.Abs = so when we go right it will be positive, and when we go left it will show again positive

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			// for transitioning jumping animation

			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}
	public void OnLanding() // public function
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate() // apply that input in the character
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump); //Time.fixedDeltaTime -- makes character speed consistent , elapsed timewhen it was last called
		jump = false; // stop jumping
	}
}