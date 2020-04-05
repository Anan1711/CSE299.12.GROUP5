using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI_6 : MonoBehaviour
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
    public float speed6 = 500f;


    // This variable is for how close an enemy needs to be to a waypoint before it moves to a target
    public float nextwaypointDistance6 = 3f;


    // Referencing our enemy character
    public Transform enemyGFX;


    // private variable. The path we are following
    Path path6;


    // This variable will store the current waypoint of the path we are targeting
    int currentWaypoint6 = 0;


    // This variable is for knowing whether or not we reached the end of the path
    bool reachedEndOfPath6 = false;


    // This Seeker is responsible for generating a path to our target
    Seeker seeker6;


    // To drive the movement of our enemy. Applying physics to our enenmy.
    Rigidbody2D rb6;


    // Start is called before the first frame update
    void Start()
    {
        // Assigning Max Health to current health.
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        // Finding the seeker component on our object
        seeker6 = GetComponent<Seeker>();


        // Finding the rigidbody component on our object
        rb6 = GetComponent<Rigidbody2D>();


        // generating our path at an interval
        // 0f = amount of time we want to wait
        // .5f = repeat rate
        InvokeRepeating("UpdatePath", 0f, .5f);


    }
    void UpdatePath()
    {
        // Checking if we are not calculation a path then we can start a new one
        if (seeker6.IsDone())
        {
            // Generating the path. StartPath takes the start position which is the emeny and an end position which is our target.
            seeker6.StartPath(rb6.position, target.position, OnPathComplete);
        }


    }

    // This function will run in the background. It will just calculate the path
    void OnPathComplete(Path p6)
    {
        // Making sure we didn't get any error
        if (!p6.error)
        {
            // Setting our courrent path to p which is the newly generated path
            path6 = p6;

            // Resetting our progress along our path to start at the begining of our new path
            currentWaypoint6 = 0;
        }

    }

    // To move our enemy along the path
    // FixedUpdate is called a fixed number of time per frame. Ideal for working with physics
    void FixedUpdate()
    {
        // Checking if we have a path or not
        if (path6 == null)
        {
            return;
        }


        // Checking if our current waypoint is eqaul or greater than the total amount of waypoints along our path
        // If it is true then we haved reached the end of the path
        if (currentWaypoint6 >= path6.vectorPath.Count)
        {
            reachedEndOfPath6 = true;

            if (reachedEndOfPath6 == true)
            {
                Attack();
            }
            return;
        }
        else
        {
            // There are more waypoint in the path. We haven't reached the end
            reachedEndOfPath6 = false;

            if (reachedEndOfPath6 == false)
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
              reachedEndOfPath6 = false;
          }
          */


        // Getting the direction to the next waypoint along our path
        // path.vectorPath[currentWaypoint] gives the position of our current waypoint
        // rb.position is our current position 
        // Gives us a vector from our position to our next waypoint
        // We are pointing and arrow from our current position to where we want to be which is our current waypoint and making sure the lenght of that arrow is 1 (normalized)
        Vector2 direction6 = ((Vector2)path6.vectorPath[currentWaypoint6] - rb6.position).normalized;


        // Getting a force we want to apply on our enemy to make it move in that direction.
        // Time.deltaTime is for making sure it doesn't vary depending on the frame rate
        Vector2 force6 = direction6 * speed6 * Time.deltaTime;


        // adding the force to our enemy
        rb6.AddForce(force6);


        // Finding the distance of our next waypoint. Which is between our current position and the next waypoint
        float distance6 = Vector2.Distance(rb6.position, path6.vectorPath[currentWaypoint6]);


        // Checking if we reached that current waypoint
        if (distance6 < nextwaypointDistance6)
        {
            // We want move to the next waypoint
            currentWaypoint6++;
        }



        // To flip our enemy towards the player
        // Checking if our current velocity of our enemy is less than some negative value means we are moving on the left 
        if (rb6.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // if it is positve then we are moving to the right
        else if (rb6.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb6.velocity.x));

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
        this.enabled = false;
        Invoke("Delete", 5f);
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
        if (reachedEndOfPath6 == true)
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
