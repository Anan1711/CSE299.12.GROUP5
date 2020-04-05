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


        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        

       

    }

}
