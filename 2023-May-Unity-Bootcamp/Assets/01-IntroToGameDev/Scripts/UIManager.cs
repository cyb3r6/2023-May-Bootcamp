using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Transform frameHolder;
    [SerializeField]
    private GameObject strikeUImessage;
    [SerializeField]
    private GameObject spareUIMessage;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject mobileInputCanvas;

    private FrameUI[] frames;

    void Start()
    {
        ResetFrameUIs();

        strikeUImessage.SetActive(false);
        spareUIMessage.SetActive(false);
        gameOverUI.SetActive(false);
        mobileInputCanvas.SetActive(false);

#if UNITY_ANDROID || UNITY_IOS
        mobileInputCanvas.SetActive(true);
#endif
    }

    public void ResetFrameUIs()
    {
        frames = new FrameUI[frameHolder.childCount];
        for(int i = 0; i < frameHolder.childCount; i++)
        {
            frames[i] = frameHolder.GetChild(i).GetComponent<FrameUI>();
            frames[i].SetFrame(i + 1);
        }
    }

    public void SetFrameValue(int frame, int throwNumber, int score)
    {
        frames[frame - 1].UpdateScore(throwNumber, score);
    }

    public void SetFrameTotal(int frame, int score)
    {
        frames[frame].UpdateTotal(score);
    }

    public void ShowStrike()
    {
        strikeUImessage.SetActive(true);
        Invoke("HideStrike", 2.0f);
    }
    public void ShowSpare()
    {
        spareUIMessage.SetActive(true);
        Invoke("HideSpare", 2.0f);
    }
    public void ShowGameOver(int total)
    {
        gameOverUI.SetActive(true);
        scoreText.text = total.ToString();
    }

    public void HideStrike()
    {
        strikeUImessage.SetActive(false);
    }
    public void HideSpare()
    {
        spareUIMessage.SetActive(false);
    }
}
