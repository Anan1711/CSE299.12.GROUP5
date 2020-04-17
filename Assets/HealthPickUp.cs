using UnityEngine;


public class HealthPickUp : MonoBehaviour
{
    PlayerHealth playerhealth;

    public HealthBar healthbar;
    
    public int healthbonus = 10;

    void Awake()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
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
        if (playerhealth.currentHealth < playerhealth.maxHealth)
        {
            Destroy(gameObject);
            playerhealth.currentHealth = playerhealth.currentHealth + healthbonus;
            healthbar.SetHealth(playerhealth.currentHealth);

        }


    }
}
