using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHealthBooster : MonoBehaviour
{
    private NPlayerMovement player;
    private NHealthBar healthbar;
    public float healthBonus = 15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<NPlayerMovement>();
        try
        {
            healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<NHealthBar>();
        }
        catch
        {

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (player.currentHealth < player.MaxHealth)
        {
            Destroy(gameObject);
            player.currentHealth = player.currentHealth + healthBonus;
            healthbar.SetHealth(player.currentHealth);


        }
    }
}
