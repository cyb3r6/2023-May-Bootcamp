using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    float currentHealth;
    float maxHealth;
    float healthRegenRate;

    private void AddHealth(float value)
    {
        currentHealth += value; // currentHealth = currentHealth + value
    }

    private void DeductHealth(float value)
    {
        currentHealth -= value;
    }


    public Health(float maxHealth, float healthRegenRate, float currentHealth = 100)
    {
        this.maxHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;
        this.currentHealth = currentHealth;
    }

    public Health(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public Health()
    {

    }

}
