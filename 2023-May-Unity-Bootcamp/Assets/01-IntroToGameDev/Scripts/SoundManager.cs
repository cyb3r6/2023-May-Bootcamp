using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Ball, pin and UI sound sources")]
    [SerializeField]
    private AudioSource ballSFX;
    [SerializeField]
    private AudioSource pinSFX; 
    [SerializeField]
    private AudioSource uiSFX;

    [Header("ball SFX clips")]
    [SerializeField]
    private AudioClip throwStartclip;
    [SerializeField]
    private AudioClip rollClip;
    [SerializeField]
    private AudioClip pinCollisionClip;
    [SerializeField]
    private AudioClip ballFallClip;

    [Header("UI SFX clips")]
    [SerializeField]
    private AudioClip buttonHoverClip;
    [SerializeField]
    private AudioClip buttonPressedClip;
    [SerializeField]
    private AudioClip spareClip;
    [SerializeField]
    private AudioClip strikeClip;

    public void PlaySound(string soundClip)
    {
        switch (soundClip)
        {
            // ball sound effects
            case "throw":
                ballSFX.PlayOneShot(throwStartclip);
                break;
            case "roll":
                ballSFX.loop = true;
                ballSFX.clip = rollClip;
                ballSFX.Play();
                break;
            case "collide":
                ballSFX.loop = false;
                ballSFX.Stop();
                ballSFX.PlayOneShot(pinCollisionClip);
                break;
            case "ballFall":
                ballSFX.loop = false;
                ballSFX.Stop();
                ballSFX.PlayOneShot(ballFallClip);
                break;
            // ui sound effects
            case "strike":
                uiSFX.PlayOneShot(strikeClip);
                break;
            case "spare":
                uiSFX.PlayOneShot(spareClip);
                break;
            case "buttonhover":
                uiSFX.PlayOneShot(buttonHoverClip);
                break;
            case "buttonpress":
                uiSFX.PlayOneShot(buttonPressedClip);
                break;

        }
    }
}
