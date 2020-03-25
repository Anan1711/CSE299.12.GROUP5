using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{



    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    public int attackDamage = 40;
    public float attackRate = 2f;
   // float nextAttackTime = 0f;

    // Update is called once per frame
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
        if (Input.GetButtonDown("Fire4"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire5"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire6"))
        {
            Attack();
        }
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack1");


        }
        else if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Attack2");
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            animator.SetTrigger("JumpAttack");
        }
        else if (Input.GetButtonDown("Fire4"))
        {
            animator.SetTrigger("Strike");
        }
        else if (Input.GetButtonDown("Fire5"))
        {
            animator.SetTrigger("UltraAtk");
        }
        else
        {
            animator.SetTrigger("FireAtk");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponent<EnemyAI_2>().TakeDamage(attackDamage);

            }
            catch
            {
                // Debug.LogError("Something is wrong 2");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
