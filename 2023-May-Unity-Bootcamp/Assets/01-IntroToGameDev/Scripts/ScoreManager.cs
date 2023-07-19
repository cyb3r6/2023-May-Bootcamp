using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private UIManager uiManager;

    private int totalScore;
    
    public int currentFrame
    {
        get;
        private set;
    }

    public int currentThrow
    {
        get;
        private set;
    }

    private int[] frames = new int[10];
    private int[] ballScores = new int[3];

    private bool isSpare = false;
    private bool isStrike = false;

    void Start()
    {
        ResetScore();
    }

    public void SetFrameScore(int score)
    {
        // set the ui
        uiManager.SetFrameValue(currentFrame, currentThrow, score);

        // check if the current throw is 1, ball 1
        if(currentThrow == 1)
        {
            frames[currentFrame - 1] += score;

            if (isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }

            if(score == 10)
            {
                if(currentFrame == 10)
                {
                    // wait for the ball 2
                    currentThrow++;
                }
                else
                {
                    isStrike = true;
                    // move to the next frame since we've gotten full marks
                    currentFrame++;

                    // show ui strike
                    uiManager.ShowStrike();
                    gameManager.soundManager.PlaySound("strike");
                }

                // reset the pins and wait for ball 2
                gameManager.ResetAllPins();
            }
            else
            {
                currentThrow++;
            }
            return;
        }

        // BALL 2!
        if(currentThrow == 2)
        {
            frames[currentFrame - 1] += (score - frames[currentFrame -1]);

            if (isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;
            }
            if(frames[currentFrame-1] == 10)
            {
                if(currentFrame == 10)
                {
                    // wait for ball 3
                    currentThrow++;
                }
                else
                {
                    isSpare = true;
                    // move to the next frame
                    currentFrame++;
                    // reset the throws to 0
                    currentThrow = 1;

                    // show ui spare
                    uiManager.ShowSpare();
                    gameManager.soundManager.PlaySound("spare");
                }
            }
            else
            {
                if(currentFrame == 10)
                {
                    // end of the line/throw
                    currentThrow = 0;
                    currentFrame = 0;
                }
                else
                {
                    // move to the next frame
                    currentFrame++;
                    // reset throws to 0
                    currentThrow = 1;
                }
            }
            // reset the pins
            gameManager.ResetAllPins();

            return;
        }

        // ball 3 *ONLY FOR FRAME 10*
        if(currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;

            // end all the throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }

    }

    public int[] GetFrameScores()
    {
        return frames;
    }
    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach(var item in frames)
        {
            totalScore += item;
        }
        return totalScore;
    }

    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];
    }
}
