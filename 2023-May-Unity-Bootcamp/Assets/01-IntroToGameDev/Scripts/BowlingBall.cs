using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    // [access modifier] [data type] [variable name] [variable value]
    private GameManager gameManager;

    bool hasCollided = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin") && !hasCollided)
        {
            hasCollided = true;
            gameManager.soundManager.PlaySound("collide");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pit"))
        {
            // play ball falling audio
            gameManager.soundManager.PlaySound("ballFall");

            // tell the game mamanger to set the next throw
            gameManager.SetNextThrow();

            // destroy this gameobject
            Destroy(gameObject);
           
        }
        else if (other.CompareTag("Closeup"))
        {
            gameManager.SwitchCamera();
        }
    }
}
