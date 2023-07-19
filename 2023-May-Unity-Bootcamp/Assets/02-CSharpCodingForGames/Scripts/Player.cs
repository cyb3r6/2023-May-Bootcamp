using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private float speed;

    private void Start()
    {
        health = new Health(100, 0.5f, 100);
    }

    public override void Move(Transform target)
    {
        base.Move(target);

    }

    public override void Shoot(Vector3 direction, float speed)
    {
        base.Shoot(direction, speed);
    }

    public override void Attack(float interval)
    {
        base.Attack(interval);
    }

    public override void Die()
    {
        Debug.Log("Player has died");
    }
}
