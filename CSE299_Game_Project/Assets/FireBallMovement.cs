using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    public float BallSpeed = 20f;
    public int FireBallDamage = 5;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Making the fireball move.
        rb.velocity = transform.right * BallSpeed;
    }

    // Register enemies when hit.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Only register if it is an enemy.
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
        if(enemy != null)
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

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        
    }
    
}
