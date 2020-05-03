using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBossHealth : MonoBehaviour
{
    public int health = 500;
	//health bar
	public NHealthBar healthBar;

	public GameObject deathEffect;

    public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
