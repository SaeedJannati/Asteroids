using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MetaMainMenuView : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreAmountText;
    [SerializeField] private Image audioButton;
    [SerializeField] private Image musicButton;
    private bool isAudioEnable;
    private bool isMusicEnable;

  
    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        highScoreAmountText.text=   MainContainer.MetaMainMenuLogic.GetHighScore().ToString();
    }

    public void PlayClick()
    {
        MainContainer.MetaMainMenuLogic.PlayTheGame();
    }

    public void ExitClick()
    {
        MainContainer.MetaMainMenuLogic.ExitTheGame();
    }

    public void AudioClick()
    {
        MainContainer.MetaMainMenuLogic.TwaekAudio();
    }

    public void MusicClick()
    {
        MainContainer.MetaMainMenuLogic.TweakMusic();
    }

   

    public void SetMusicButtonAppearance(bool enabled)
    {
        var colour = enabled
            ? MainContainer.MetaMainMenuLogic.GetActiveColor()
            : MainContainer.MetaMainMenuLogic.GetDeactiveColor();
        musicButton.color = colour;
    }
    public void SetAudioButtonAppearance(bool enabled)
    {
        var colour = enabled
            ? MainContainer.MetaMainMenuLogic.GetActiveColor()
            : MainContainer.MetaMainMenuLogic.GetDeactiveColor();
        audioButton.color = colour;
    }
}
