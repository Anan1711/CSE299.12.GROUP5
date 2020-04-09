using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    private playerMovement knight;
    int damageAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        
    }
    
    
    void OnTriggerEnter2D(Collider2D col)
    { 
        
        if(col.CompareTag("Player"))
        {
            knight.TakeDamage(damageAmount);
        }
    }
   
}
