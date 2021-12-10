using System.Collections;
using System.Collections.Generic;
using SceneLoaderManager;
using UnityEngine;

public class MetaMainMenuLogic : MonoBehaviour
{
    #region Fields
    [SerializeField] private MetaMainMenuModel config;
    

    #endregion

    #region Monobehaviour callbacks

    

    #endregion

    #region Methods

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
    }

    public void TweakMusic()
    {
        
    }

    #endregion
    
}
