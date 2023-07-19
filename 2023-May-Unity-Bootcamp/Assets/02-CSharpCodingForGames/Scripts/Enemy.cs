using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    private float speed;
    private EnemyType enemyType;
    private Transform target;

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
        base.Die();
    }
    public void SetEnemyType(EnemyType type)
    {
        this.enemyType = type;
    }

}
