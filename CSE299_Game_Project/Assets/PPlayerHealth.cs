﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public PHealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y <= -20)
		{
			TakeDamage(10);
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			PGameMaster.KillPlayer(this);
		}
		healthBar.SetHealth(currentHealth);
	}
}