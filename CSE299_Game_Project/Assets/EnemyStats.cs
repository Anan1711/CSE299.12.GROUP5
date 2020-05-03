using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStats : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 200;
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
        if(currentHealth <= 0)
        {
            EnemyDeath();
        }

    }

    void EnemyDeath()
    {
        // Die animation
        animator.SetBool("Isdead", true);

        // Disable the enemy
        //GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
      


    }


    
}
