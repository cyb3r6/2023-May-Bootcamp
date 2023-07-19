using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string name;
    float damage;

    private void Shoot()
    {

    }

    /// <summary>
    /// Weapon Constructor
    /// </summary>
    public Weapon(string name, float damage)
    {
        this.name = name;
        this.damage = damage;
    }
}
