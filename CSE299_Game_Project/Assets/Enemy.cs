using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Enemy : MonoBehaviour
{

   
    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
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
            Die();
        }
        
    }

    void Die()
    {
        Debug.Log("Enemy died");
        // Die animation
        animator.SetBool("IsDead", true);
       // { 

        // Disable the enemy
        //GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        //  this.GetComponent<AIPath>().enabled = false;
        // }
        
        
            GetComponent<AIDestinationSetter>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        GetComponent<Seeker>().enabled = false;



        //this.GetComponent(NavMeshAgent).Stop();
        this.enabled = false;
        






    }



}
