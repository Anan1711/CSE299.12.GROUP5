using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

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

    }
    void Attack()
    {
        // Play an attack animation
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
        
        
        // Detect enemy in range of attack
        // Apply Damage
    }
}