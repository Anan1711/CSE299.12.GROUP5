﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI_8 : MonoBehaviour
{
    public HealthBar healthBar;
    public Animator animator;
    public Transform EnemyAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayers;
    public float attackDamage;
    public GameObject deathEffect;

    // Max health of the enemy
    public int MaxHealth = 100;

    // Current health
    int currentHealth;

    // This variable will reference our target (player)
    public Transform target;

    // This variable will control the speed
    public float speed8 = 500f;


    // This variable is for how close an enemy needs to be to a waypoint before it moves to a target
    public float nextwaypointDistance8 = 3f;


    // Referencing our enemy character
    public Transform enemyGFX;


    // private variable. The path we are following
    Path path8;


    // This variable will store the current waypoint of the path we are targeting
    int currentWaypoint8 = 0;


    // This variable is for knowing whether or not we reached the end of the path
    bool reachedEndOfPath8 = false;


    // This Seeker is responsible for generating a path to our target
    Seeker seeker8;


    // To drive the movement of our enemy. Applying physics to our enenmy.
    Rigidbody2D rb8;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning Max Health to current health.
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        // Finding the seeker component on our object
        seeker8 = GetComponent<Seeker>();


        // Finding the rigidbody component on our object
        rb8 = GetComponent<Rigidbody2D>();


        // generating our path at an interval
        // 0f = amount of time we want to wait
        // .5f = repeat rate
        InvokeRepeating("UpdatePath", 0f, .5f);


    }
    void UpdatePath()
    {
        // Checking if we are not calculation a path then we can start a new one
        if (seeker8.IsDone())
        {
            // Generating the path. StartPath takes the start position which is the emeny and an end position which is our target.
            seeker8.StartPath(rb8.position, target.position, OnPathComplete);
        }


    }

    // This function will run in the background. It will just calculate the path
    void OnPathComplete(Path p8)
    {
        // Making sure we didn't get any error
        if (!p8.error)
        {
            // Setting our courrent path to p which is the newly generated path
            path8 = p8;

            // Resetting our progress along our path to start at the begining of our new path
            currentWaypoint8 = 0;
        }

    }

    // To move our enemy along the path
    // FixedUpdate is called a fixed number of time per frame. Ideal for working with physics
    void FixedUpdate()
    {
        // Checking if we have a path or not
        if (path8 == null)
        {
            return;
        }


        // Checking if our current waypoint is eqaul or greater than the total amount of waypoints along our path
        // If it is true then we haved reached the end of the path
        if (currentWaypoint8 >= path8.vectorPath.Count)
        {
            reachedEndOfPath8 = true;

            if (reachedEndOfPath8 == true)
            {
                Attack();
            }
            return;
        }
        else
        {
            // There are more waypoint in the path. We haven't reached the end
            reachedEndOfPath8 = false;

            if (reachedEndOfPath8 == false)
            {
                StopAttack();
            }

        }

        /*  
          return;
          }
          else
          {
              // There are more waypoint in the path. We haven't reached the end
              reachedEndOfPath8 = false;
          }
          */


        // Getting the direction to the next waypoint along our path
        // path.vectorPath[currentWaypoint] gives the position of our current waypoint
        // rb.position is our current position 
        // Gives us a vector from our position to our next waypoint
        // We are pointing and arrow from our current position to where we want to be which is our current waypoint and making sure the lenght of that arrow is 1 (normalized)
        Vector2 direction8 = ((Vector2)path8.vectorPath[currentWaypoint8] - rb8.position).normalized;


        // Getting a force we want to apply on our enemy to make it move in that direction.
        // Time.deltaTime is for making sure it doesn't vary depending on the frame rate
        Vector2 force8 = direction8 * speed8 * Time.deltaTime;


        // adding the force to our enemy
        rb8.AddForce(force8);


        // Finding the distance of our next waypoint. Which is between our current position and the next waypoint
        float distance8 = Vector2.Distance(rb8.position, path8.vectorPath[currentWaypoint8]);


        // Checking if we reached that current waypoint
        if (distance8 < nextwaypointDistance8)
        {
            // We want move to the next waypoint
            currentWaypoint8++;
        }



        // To flip our enemy towards the player
        // Checking if our current velocity of our enemy is less than some negative value means we are moving on the left 
        if (rb8.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // if it is positve then we are moving to the right
        else if (rb8.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb8.velocity.x));

    }
    #region Enemy Hurt and Death
    // Function for taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // play hurt animation
        animator.SetTrigger("Hurt");
        if (currentHealth != 0)
        {
            AttackAgain();
        }


        // if no health remains then enemy dies
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }

    }

    void AttackAgain()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(EnemyAttackPoint.position, attackRange, PlayerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            try
            {
                if (player.GetComponent<PlayerMovement>().currentHealth != 0)
                {
                    player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
                }
                else
                {
                    StopAttack();
                }
            }
            catch
            {

            }
        }
    }

    void EnemyDeath()
    {
        // Die animation
        animator.SetBool("IsDead", true);


        // Disable the enemy

        GetComponent<BoxCollider2D>().enabled = false;
      //  GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
        Invoke("Delete", 3f);
    }
    // Instantiate(deathEffect, transform.position, Quaternion.identity);
    void Delete()
    {
        Destroy(gameObject);
    }


    #endregion

    #region Enemy Attack
    void Attack()
    {
        if (reachedEndOfPath8 == true)
        {
            animator.SetBool("Attack", true);
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(EnemyAttackPoint.position, attackRange, PlayerLayers);

            foreach (Collider2D player in hitPlayer)
            {
                try
                {
                    if (player.GetComponent<PlayerMovement>().currentHealth != 0)
                    {
                        player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
                    }
                    else
                    {
                        StopAttack();
                    }
                }
                catch
                {

                }
            }
        }
    }
    void StopAttack()
    {
        animator.SetBool("Attack", false);
    }


    void OnDrawGizmosSelected()
    {
        if (EnemyAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(EnemyAttackPoint.position, attackRange);
    }
    #endregion

}