 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Play an attack animation
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");


        }

    }

}
