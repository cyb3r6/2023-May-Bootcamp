using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    private float damage;
    private void Move(Transform target)
    {
        Debug.Log($"bullet is moving towards {target}");
    }

    private void DoDamage()
    {
        Debug.Log("Damaged target");

        LevelLoader.score++;
    }
}
