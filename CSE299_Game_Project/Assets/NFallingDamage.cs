using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFallingDamage : MonoBehaviour
{
    private NPlayerMovement knight;
    int damageAmount =999999;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<NPlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            knight.TakeDamage(damageAmount);
        }
    }
}
