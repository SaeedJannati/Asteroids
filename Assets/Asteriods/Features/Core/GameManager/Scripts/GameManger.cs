using System;
using System.Collections;
using System.Collections.Generic;
using SceneLoaderManager;

using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerHealthLogic.OnGameEnd += GameOver;
    }

    private void OnDisable()
    {
        PlayerHealthLogic.OnGameEnd -= GameOver;
    }

    public void ResetGame()
    {
        MainContainer.SceneLoader.LoadScene(SceneName.Core);
    }

    public void ReturnToCore()
    {
        MainContainer.SceneLoader.LoadScene(SceneName.Meta);
    }

    public void GameOver()
    {
        MainContainer.AstroidGenerator.ClearAllAStroids();
        var popUp = MainContainer.PopUpManager.RequestPopup(MainContainer.PrefabContainer.CoreMenu);
        ((CoreMenuPopup)popUp).BringUp(true);
    }
}
