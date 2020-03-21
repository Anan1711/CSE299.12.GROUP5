using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Enemy : MonoBehaviour
{
    #region Attack Variables
    
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayers;
    public int attackDamage;
    #endregion

    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;

  
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


    void FixedUpdate()
    {
       


      

     
    }




        #region Enemy Attack
        void Attack()
    {

        animator.SetBool("Attack", true);
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, PlayerLayers);
        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("WE hit" + player.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    #endregion

}

