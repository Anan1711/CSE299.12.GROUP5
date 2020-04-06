using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    public float BallSpeed = 20f;
    public int FireBallDamage = 5;
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
        EnemyAl_1 enemy = hitInfo.GetComponent<EnemyAl_1>();
        if (enemy != null)
        {
            enemy.TakeDamage(FireBallDamage);
        }
        EnemyAI_2 enemy2 = hitInfo.GetComponent<EnemyAI_2>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(FireBallDamage);
        }
        EnemyAI_3 enemy3 = hitInfo.GetComponent<EnemyAI_3>();
        if (enemy3 != null)
        {
            enemy3.TakeDamage(FireBallDamage);
        }
        EnemyAI_4 enemy4 = hitInfo.GetComponent<EnemyAI_4>();
        if (enemy4 != null)
        {
            enemy4.TakeDamage(FireBallDamage);
        }
        EnemyAI_5 enemy5 = hitInfo.GetComponent<EnemyAI_5>();
        if (enemy5 != null)
        {
            enemy5.TakeDamage(FireBallDamage);
        }
        EnemyAI_6 enemy6 = hitInfo.GetComponent<EnemyAI_6>();
        if (enemy6 != null)
        {
            enemy6.TakeDamage(FireBallDamage);
        }
        EnemyAI_7 enemy7 = hitInfo.GetComponent<EnemyAI_7>();
        if (enemy7 != null)
        {
            enemy7.TakeDamage(FireBallDamage);
        }

        EnemyAI_8 enemy8 = hitInfo.GetComponent<EnemyAI_8>();
        if (enemy8 != null)
        {
            enemy8.TakeDamage(FireBallDamage);
        }

        EnemyAI_9 enemy9 = hitInfo.GetComponent<EnemyAI_9>();
        if (enemy9 != null)
        {
            enemy9.TakeDamage(FireBallDamage);
        }
     
       


        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        

       

    }

}
