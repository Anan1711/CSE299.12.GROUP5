using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Animator animator;

    // Max health of the enemy
    public int MaxHealth = 200;

    // Current health
    int currentHealth;


    // This variable will reference our target (player)
    public Transform target;

    // This variable will control the speed
    public float speed = 500f;
    

    // This variable is for how close an enemy needs to be to a waypoint before it moves to a target
    public float nextwaypointDistance = 3f;
    

    // Referencing our enemy character
    public Transform enemyGFX;
    

    //  variable. The path we are following
    Path path;
    

    // This variable will store the current waypoint of the path we are targeting
    int currentWaypoint = 0;
    

    // This variable is for knowing whether or not we reached the end of the path
    bool reachedEndOfPath = false;
    

    // This Seeker is responsible for generating a path to our target
    Seeker seeker;
    

    // To drive the movement of our enemy. Applying physics to our enenmy.
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        // Assigning Max Health to current health.
        currentHealth = MaxHealth;

        // Finding the seeker component on our object
        seeker = GetComponent<Seeker>();
        

        // Finding the rigidbody component on our object
        rb = GetComponent<Rigidbody2D>();
        

        // generating our path at an interval
        // 0f = amount of time we want to wait
        // .5f = repeat rate
        InvokeRepeating("UpdatePath", 0f, .5f);
      }

    void UpdatePath()
    {
        // Checking if we are not calculation a path then we can start a new one
        if(seeker.IsDone())
        {
            // Generating the path. StartPath takes the start position which is the emeny and an end position which is our target.
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
      }

    // This function will run in the background. It will just calculate the path
    void OnPathComplete(Path p)
    {
        // Making sure we didn't get any error
        if(!p.error)
        {
            // Setting our courrent path to p which is the newly generated path
            path = p;

            // Resetting our progress along our path to start at the begining of our new path
            currentWaypoint = 0;
        }
      }

    // To move our enemy along the path
    // FixedUpdate is called a fixed number of time per frame. Ideal for working with physics
    void FixedUpdate()
    {
        // Checking if we have a path or not
        if (path == null)
        {
            return;
        }
        

        // Checking if our current waypoint is eqaul or greater than the total amount of waypoints along our path
        // If it is true then we haved reached the end of the path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            // There are more waypoint in the path. We haven't reached the end
            reachedEndOfPath = false;
        }

        

        // Getting the direction to the next waypoint along our path
        // path.vectorPath[currentWaypoint] gives the position of our current waypoint
        // rb.position is our current position 
        // Gives us a vector from our position to our next waypoint
        // We are pointing and arrow from our current position to where we want to be which is our current waypoint and making sure the lenght of that arrow is 1 (normalized)
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        

        // Getting a force we want to apply on our enemy to make it move in that direction.
        // Time.deltaTime is for making sure it doesn't vary depending on the frame rate
        Vector2 force = direction * speed * Time.deltaTime;
        

        // adding the force to our enemy
        rb.AddForce(force);
       

        // Finding the distance of our next waypoint. Which is between our current position and the next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        

        // Checking if we reached that current waypoint
        if (distance < nextwaypointDistance)
        {
            // We want move to the next waypoint
            currentWaypoint++;
        }

        

        // To flip our enemy towards the player
        // Checking if our current velocity of our enemy is less than some negative value means we are moving on the left 
        if (rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // if it is positve then we are moving to the right
        else if(rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        
    }

    // Function for taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // play hurt animation
        animator.SetTrigger("Hurt");

        // if no health remains then enemy dies
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }

    }

    void EnemyDeath()
    {
        // Die animation
        animator.SetBool("Isdead", true);

        // Disable the enemy
        
        GetComponent<BoxCollider2D>().enabled = false;

       

        this.enabled = false;
    
    }



















}
