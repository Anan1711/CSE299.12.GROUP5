using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baal : MonoBehaviour
{
    PPlayerHealth playerhealth;

    public int healthbonus = 10;

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
