using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTrapScript : MonoBehaviour
{
    private NPlayerMovement Player;
    int damageAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<NPlayerMovement>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            Player.TakeDamage(damageAmount);
        }
    }

}
