using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for playable objects like the player and enemies
/// </summary>
public class PlayableObject : MonoBehaviour, IDamageable
{
    public Health health = new Health();
    public Weapon weapon;

    public virtual void Move(Transform target)
    {

    }

    public virtual void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"{this.gameObject.name} is shooting in {direction} direction with a speed of{speed}");
    }

    public virtual void Attack(float interval)
    {

    }
    public virtual void Die()
    {
        Debug.Log($"{name} has died with");
    }

    public void GetDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
