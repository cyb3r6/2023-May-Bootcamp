using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private Pin[] pins;

    private bool isGamePlaying = false;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGamePlaying = true;

        // Get the first throw
        SetNextThrow();
    }

    public void SetNextThrow()
    {
        // calcualte the fallen pins
        CalculateFallenPins();

        // let the player start to throw
        player.StartThrow();
    }

    public void CalculateFallenPins()
    {
        int count = 0;
        foreach(Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;    // count = count + 1;
            }
        }

        Debug.Log($"Total fallen comrades {count}");
    }
}
