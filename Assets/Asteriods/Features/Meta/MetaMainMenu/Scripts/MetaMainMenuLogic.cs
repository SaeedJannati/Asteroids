using System;
using System.Collections;
using System.Collections.Generic;
using SceneLoaderManager;
using UnityEngine;

public class MetaMainMenuLogic : MonoBehaviour
{
    #region Fields
    [SerializeField] private MetaMainMenuModel config;
    [SerializeField] private MetaMainMenuView view;

    #endregion

    #region Monobehaviour callbacks

    private void OnEnable()
    {
        AudioManager.OnAudioEnableChanged += ChangeViewAudioButtonAppearence;
        AudioManager.OnMusicEnableChanged += ChangeViewMusicButtonAppearence;
    }

    private void Start()
    {
        SetViewVfxButtonsAppearence();
    }

    private void OnDisable()
    {
        AudioManager.OnAudioEnableChanged -= ChangeViewAudioButtonAppearence;
        AudioManager.OnMusicEnableChanged -= ChangeViewMusicButtonAppearence;
    }

    #endregion

    #region Methods

    public void SetViewVfxButtonsAppearence()
    {
        view.SetAudioButtonAppearance(MainContainer.AudioManager.GetAudioEnable());
        view.SetMusicButtonAppearance(MainContainer.AudioManager.GetMusicEnable());
    }
    

    public Color GetActiveColor()
    {
        return config.activeColour;
        
    }

    public Color GetDeactiveColor()
    {
        return config.deactiveColour;
    }

    public int GetHighScore()
    {
        return MainContainer.ScoreLogic.GetHighScore();
    }

    public void PlayTheGame()
    {
        MainContainer.SceneLoader.LoadScene(SceneName.Core);
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void TwaekAudio()
    {
        MainContainer.AudioManager.ChangeAudioEnable();
    }

    public void TweakMusic()
    {
        MainContainer.AudioManager.ChangeMusicEnable();
    }

    void ChangeViewAudioButtonAppearence()
    {
        view.SetAudioButtonAppearance(MainContainer.AudioManager.GetAudioEnable());
    }
    void ChangeViewMusicButtonAppearence()
    {
        view.SetMusicButtonAppearance(MainContainer.AudioManager.GetMusicEnable());
    }
    #endregion
    
}
