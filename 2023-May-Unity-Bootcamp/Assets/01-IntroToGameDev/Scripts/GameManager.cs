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
    private UIManager uiManager;

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
        int fallenPins = CalculateFallenPins();

        scoreManager.SetFrameScore(fallenPins);

        // see if the current frame is the first one
        if(scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game over! Score is: {scoreManager.CalculateTotalScore()}");

            uiManager.ShowGameOver(scoreManager.CalculateTotalScore());
            return;
        }
        // calculate frame totals for the UI
        int frameTotal = 0;
        for(int i = 0; i < scoreManager.currentFrame -1; i++)
        {
            frameTotal += scoreManager.GetFrameScores()[i];
            uiManager.SetFrameTotal(i, frameTotal);
        }

        player.StartThrow();
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
