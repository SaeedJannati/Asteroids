using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MetaMainMenuView : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreAmountText;
    [SerializeField] private Button audioButton;
    [SerializeField] private Button musicButton;
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
}
