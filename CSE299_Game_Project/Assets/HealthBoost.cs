using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    private playerMovement player;
    private HealthBar healthbar;
    public float healthBonus = 15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        try
        {
            healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        }
        catch
        {

        }
    }     
    void OnTriggerEnter2D(Collider2D col)
    {
        if(player.currentHealth < player.MaxHealth)
        {
            Destroy(gameObject);
            player.currentHealth = player.currentHealth + healthBonus;
            healthbar.SetHealth(player.currentHealth);
            
           
        }
    }
}
