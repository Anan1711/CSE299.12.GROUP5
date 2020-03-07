using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    // Referencing the AttackPoint Object under Knight.
    public Transform AttackPoint;
    

    // Detect which is an enemy.
    public LayerMask enemyLayers;
    


    // Range of the attack
    public float attackRange = 0.5f;
    

    public int attackDamage = 40;

   
    

    // Update is called once per frame.
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Attack();
        }

    }
    void Attack()
    {
        // Play an attack animation.
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("BigAttack");
        }
        else
        {
            animator.SetTrigger("CastAttack");
        }


        // Detect enemy in range of attack.
        // Creats an object around the AttackPoint object to collect all obejct that this circle hits.
        // hitEnemies an array of all enemy we hit.
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,enemyLayers);





        // Apply Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
               
            }
            catch
            {
               // Debug.LogError("Something is wrong 1");
            }
            try
            {
                enemy.GetComponent<EnemyAI_2>().TakeDamage(attackDamage);

            }
            catch
            {
               // Debug.LogError("Something is wrong 2");
            }
            try
            {
                enemy.GetComponent<EnemyAI_3>().TakeDamage(attackDamage);

            }
            catch 
            {
               // Debug.LogError("Something is wrong 3");
            }
            

        }
        





    }

    void OnDrawGizmosSelected()
    {
        if(AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
