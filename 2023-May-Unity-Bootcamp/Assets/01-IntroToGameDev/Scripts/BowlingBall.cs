using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    // [access modifier] [data type] [variable name] [variable value]
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            Debug.Log("Collided with pin!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pit"))
        {
            Debug.Log("entered the PIT");
            // tell the game mamanger to set the next throw
            gameManager.SetNextThrow();

            // destroy this gameobject
            Destroy(gameObject);
        }
    }
}
