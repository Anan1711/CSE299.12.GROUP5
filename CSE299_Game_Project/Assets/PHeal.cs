using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHeal : MonoBehaviour
{
    PPlayerHealth playerhealth;

    public int healthbonus = 20;

    void Awake()
    {
        playerhealth = FindObjectOfType<PPlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerhealth.currentHealth < playerhealth.maxHealth)
        {
            Destroy(gameObject);
            playerhealth.currentHealth = playerhealth.currentHealth + healthbonus;
        }
    }
}
