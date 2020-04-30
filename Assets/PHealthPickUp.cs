using UnityEngine;


public class PHealthPickUp : MonoBehaviour
{
    PPlayerHealth playerhealth;

    public PHealthBar healthbar;
    
    public int healthbonus = 10;

    void Awake()
    {
        playerhealth = FindObjectOfType<PPlayerHealth>();
        try
        {
            healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<PHealthBar>();
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
