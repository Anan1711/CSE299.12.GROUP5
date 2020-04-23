using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //referencing CharacterController2D controller
    //---------------------------------------------HEALTH
    public float MaxHealth = 100;
    public float currentHealth;
    //health bar
    public HealthBar healthBar;


    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public GameObject Player;

    void Start()
    {
        currentHealth = MaxHealth;
        //healthbar
        healthBar.SetMaxHealth(MaxHealth);

    }

    void Update()
    //apply that input to our player
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        // movement horizontal or X axis
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        else
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    //apply that input to our chararter
    {
        //referencing CharacterController2D
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //Time.fixedDeltaTime is amount of time elapsed since last func called
        jump = false;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //HealthBar
        healthBar.SetHealth(currentHealth);

        // play hurt animation
        animator.SetTrigger("Hurt");

        // if no health remains then enemy dies
        if (currentHealth <= 0)
        {
            PlayerDeath();
        }

    }
    void PlayerDeath()
    {
        Debug.Log("Player Died");
        // Die animation
        animator.SetBool("Isdead", true);

        // Disable the enemy

        GetComponent<BoxCollider2D>().enabled = false;
        // GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coins"))
        {

            Destroy(other.gameObject);
        }


    }

}



