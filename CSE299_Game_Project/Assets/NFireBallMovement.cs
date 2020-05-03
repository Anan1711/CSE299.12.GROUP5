using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFireBallMovement : MonoBehaviour
{
    public float BallSpeed = 20f;
    public int FireBallDamage = 3;
    public Rigidbody2D rb;
    public GameObject ImpactEffect;
    // Start is called before the first frame update 
    void Start()
    {
        rb.velocity = transform.right * BallSpeed;
    }

    // Register enemies when hit.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        NEnemyAl_1 enemy = hitInfo.GetComponent<NEnemyAl_1>();
        if (enemy != null)
        {
            enemy.TakeDamage(FireBallDamage);
        }
        NEnemyAI_2 enemy2 = hitInfo.GetComponent<NEnemyAI_2>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(FireBallDamage);
        }
        NEnemyAI_3 enemy3 = hitInfo.GetComponent<NEnemyAI_3>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(FireBallDamage);
        }
        NEnemyAI_4 enemy4 = hitInfo.GetComponent<NEnemyAI_4>();
        if (enemy4 != null)
        {
            enemy4.TakeDamage(FireBallDamage);
        }
        NEnemyAI_5 enemy5 = hitInfo.GetComponent<NEnemyAI_5>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(FireBallDamage);
        }
        NEnemyAI_6 enemy6 = hitInfo.GetComponent<NEnemyAI_6>();
        if (enemy6 != null)
        {
            enemy6.TakeDamage(FireBallDamage);
        }
        NEnemyAI_7 enemy7 = hitInfo.GetComponent<NEnemyAI_7>();
        if (enemy7 != null)
        {
            enemy7.TakeDamage(FireBallDamage);
        }

        NEnemyAI_8 enemy8 = hitInfo.GetComponent<NEnemyAI_8>();
        if (enemy8 != null)
        {
            enemy8.TakeDamage(FireBallDamage);
        }

        NEnemyAI_9 enemy9 = hitInfo.GetComponent<NEnemyAI_9>();
        if (enemy9 != null)
        {
            enemy9.TakeDamage(FireBallDamage);
        }
        NBossHealth enemy10 = hitInfo.GetComponent<NBossHealth>();
        if (enemy10 != null)
        {
            enemy10.TakeDamage(FireBallDamage);
        }




        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        

       

    }

}
