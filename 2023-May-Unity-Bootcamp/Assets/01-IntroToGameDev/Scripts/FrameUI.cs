using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text frameText;
    [SerializeField]
    private TMP_Text throw1Text;
    [SerializeField]
    private TMP_Text throw2Text;
    [SerializeField]
    private TMP_Text throw3Text;
    [SerializeField]
    private TMP_Text totalText;
    [SerializeField]
    private bool isFinalFrame;

    private int frameScore = 0;

    public void UpdateScore(int throwNumber, int score)
    {
        if (!isFinalFrame)
        {
            if(throwNumber == 1)
            {
                if(score == 10)
                {
                    throw1Text.text = "";
                    throw2Text.text = "X";
                }
                else
                {
                    throw1Text.text = score.ToString();
                    frameScore += score;
                }
            }
            else if(throwNumber == 2)
            {
                frameScore += score;

                if(frameScore == 10)
                {
                    throw2Text.text = "/";
                }
                else
                {
                    throw2Text.text = score.ToString();
                }
            }
        }
        else
        {
            if(throwNumber == 1)
            {
                if (score == 10)
                {
                    throw1Text.text = "";
                    throw2Text.text = "X";
                }
                else
                {
                    throw1Text.text = score.ToString();
                    frameScore += score;
                }
            }
            else if (throwNumber == 2)
            {
                frameScore += score;

                if (frameScore == 10)
                {
                    throw2Text.text = "/";
                }
                else
                {
                    throw2Text.text = score.ToString();
                }
            }
            else if (throwNumber == 3)
            {
                // regular 'if' statement
                //if (score == 10)
                //{
                //    throw3Text.text = "X";

                //}
                //else
                //{
                //    throw3Text.text = score.ToString();
                //}

                // ternary operator
                throw3Text.text = score == 10 ? "X" : score.ToString();
            }
        }
    }

    public void UpdateTotal(int total)
    {
        totalText.text = total.ToString();
    }

    public void SetFrame(int frame)
    {
        frameText.text = frame.ToString();
        throw1Text.text = "";
        throw2Text.text = "";
        totalText.text = "";

        if (isFinalFrame)
        {
            throw3Text.text = "";
        }
    }
}

