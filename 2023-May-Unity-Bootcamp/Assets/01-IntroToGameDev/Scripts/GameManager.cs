using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private ScoreManager scoreManager;

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

        // getting the first throw
        player.StartThrow();
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);
    }
    private void NextThrow()
    {
        // see if the current frame is the first one
        if(scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game over! Score is: {scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"Frame is: {scoreManager.currentFrame}. Throw is: {scoreManager.currentThrow}");

            scoreManager.SetFrameScore(CalculateFallenPins());

            Debug.Log($"Current score is: {scoreManager.CalculateTotalScore()}");
            player.StartThrow();
        }
    }

    public void ResetAllPins()
    {
        foreach(Pin pin in pins)
        {
            pin.ResetPin();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;
        foreach(Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;    // count = count + 1;
                pin.gameObject.SetActive(false);
            }
        }
        return count;
    }
}
