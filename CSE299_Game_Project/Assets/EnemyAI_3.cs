using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI_3 : MonoBehaviour
{
    #region Attack Variables
    public Animator animator;
    public Transform EnemyAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayers;
    public float attackDamage;
    #endregion

    #region Health Variables
    // Max health of the enemy
    public int MaxHealth = 200;

    // Current health
    int currentHealth;
    #endregion

    #region PathFinder Variables
    // This variable will reference our target (player)
    public Transform target;

    // This variable will control the speed
    public float speed3 = 500f;


    // This variable is for how close an enemy needs to be to a waypoint before it moves to a target
    public float nextwaypointDistance3 = 3f;


    // Referencing our enemy character
    public Transform enemyGFX;


    //  variable. The path we are following
    Path path3;


    // This variable will store the current waypoint of the path we are targeting
    int currentWaypoint3 = 0;


    // This variable is for knowing whether or not we reached the end of the path
    bool reachedEndOfPath3 = false;


    // This Seeker is responsible for generating a path to our target
    Seeker seeker3;


    // To drive the movement of our enemy. Applying physics to our enenmy.
    Rigidbody2D rb3;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Assigning Max Health to current health.
        currentHealth = MaxHealth;

        // Finding the seeker component on our object
        seeker3 = GetComponent<Seeker>();


        // Finding the rigidbody component on our object
        rb3 = GetComponent<Rigidbody2D>();


        // generating our path at an interval
        // 0f = amount of time we want to wait
        // .5f = repeat rate
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    #region Pathfinder
    void UpdatePath()
    {
        // Checking if we are not calculation a path then we can start a new one
        if (seeker3.IsDone())
        {
            // Generating the path. StartPath takes the start position which is the emeny and an end position which is our target.
            seeker3.StartPath(rb3.position, target.position, OnPathComplete);
        }
    }

    // This function will run in the background. It will just calculate the path
    void OnPathComplete(Path p)
    {
        // Making sure we didn't get any error
        if (!p.error)
        {
            // Setting our courrent path to p which is the newly generated path
            path3 = p;

            // Resetting our progress along our path to start at the begining of our new path
            currentWaypoint3 = 0;
        }
    }

    // To move our enemy along the path
    // FixedUpdate is called a fixed number of time per frame. Ideal for working with physics
    void FixedUpdate()
    {
        // Checking if we have a path or not
        if (path3 == null)
        {
            return;
        }


        // Checking if our current waypoint is eqaul or greater than the total amount of waypoints along our path
        // If it is true then we haved reached the end of the path
        if (currentWaypoint3 >= path3.vectorPath.Count)
        {
            reachedEndOfPath3 = true;
            if (reachedEndOfPath3 == true)
            {
                Attack();
            }
            return;
        }
        else
        {
            // There are more waypoint in the path. We haven't reached the end
            reachedEndOfPath3 = false;
            if (reachedEndOfPath3 == false)
            {
                StopAttack();
            }
        }



        // Getting the direction to the next waypoint along our path
        // path.vectorPath[currentWaypoint] gives the position of our current waypoint
        // rb.position is our current position 
        // Gives us a vector from our position to our next waypoint
        // We are pointing and arrow from our current position to where we want to be which is our current waypoint and making sure the lenght of that arrow is 1 (normalized)
        Vector2 direction3 = ((Vector2)path3.vectorPath[currentWaypoint3] - rb3.position).normalized;


        // Getting a force we want to apply on our enemy to make it move in that direction.
        // Time.deltaTime is for making sure it doesn't vary depending on the frame rate
        Vector2 force3 = direction3 * speed3 * Time.deltaTime;


        // adding the force to our enemy
        rb3.AddForce(force3);


        // Finding the distance of our next waypoint. Which is between our current position and the next waypoint
        float distance3 = Vector2.Distance(rb3.position, path3.vectorPath[currentWaypoint3]);


        // Checking if we reached that current waypoint
        if (distance3 < nextwaypointDistance3)
        {
            // We want move to the next waypoint
            currentWaypoint3++;
        }



        // To flip our enemy towards the player
        // Checking if our current velocity of our enemy is less than some negative value means we are moving on the left 
        if (rb3.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // if it is positve then we are moving to the right
        else if (rb3.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb3.velocity.x));


    }
    #endregion

    #region Enemy Hurt and Death
    // Function for taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
        Collider2D[] hitPlayer3 = Physics2D.OverlapCircleAll(EnemyAttackPoint.position, attackRange, PlayerLayers);

        foreach (Collider2D player in hitPlayer3)
        {
            try
            {
                if (player.GetComponent<playerMovement>().currentHealth != 0)
                {
                    player.GetComponent<playerMovement>().TakeDamage(attackDamage);
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

    }
    #endregion

    #region Enemy Attack
    void Attack()
    {
        if (reachedEndOfPath3 == true)
        {
            animator.SetBool("IsAttacking", true);
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(EnemyAttackPoint.position, attackRange, PlayerLayers);

            foreach (Collider2D player in hitPlayer)
            {
                try
                {
                    if (player.GetComponent<playerMovement>().currentHealth != 0)
                    {
                        player.GetComponent<playerMovement>().TakeDamage(attackDamage);
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
        animator.SetBool("IsAttacking", false);
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
