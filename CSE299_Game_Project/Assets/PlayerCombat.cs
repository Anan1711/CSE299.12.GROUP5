using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{



    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    public int attackDamage1;      //Blue
    public int attackDamage2;      //Red
    public int attackDamage3;      //Strike
    public int attackDamage4;      //Ultra

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
       // if (Input.GetButtonDown("Fire3"))
       // {
        //    Attack();
       // }
        if (Input.GetButtonDown("Fire4"))
        {
            Attack();
        }
        if (Input.GetButtonDown("Fire5"))
        {
           Attack();
      }
     //  if (Input.GetButtonDown("Fire6"))
       // {
       //    Attack();
       // }
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
       // else if (Input.GetButtonDown("Fire3"))
       // {
         //   animator.SetTrigger("JumpAttack");
       // }
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
                if(Input.GetButtonDown("Fire1"))
                { 
                enemy.GetComponent<EnemyAl_1>().TakeDamage(attackDamage1);
                }
                else if(Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAl_1>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAl_1>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAl_1>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 1");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_2>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_2>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_2>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_2>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 2");
            }


            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_3>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_3>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_3>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_3>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 3");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_4>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_4>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_4>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_4>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 4");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_5>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_5>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_5>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_5>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 5");
            }


            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_6>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_6>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_6>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_6>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 6");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_7>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_7>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_7>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_7>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 7");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_8>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_8>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_8>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_8>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 8");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<EnemyAI_9>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<EnemyAI_9>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<EnemyAI_9>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<EnemyAI_9>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong 2");
            }

            try
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    enemy.GetComponent<BossHealth>().TakeDamage(attackDamage1);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    enemy.GetComponent<BossHealth>().TakeDamage(attackDamage2);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    enemy.GetComponent<BossHealth>().TakeDamage(attackDamage3);
                }
                else if (Input.GetButtonDown("Fire5"))
                {
                    enemy.GetComponent<BossHealth>().TakeDamage(attackDamage4);
                }
            }
            catch
            {
                // Debug.LogError("Something is wrong boss");
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
