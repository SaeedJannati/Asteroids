using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SceneLoaderManager;
using UnityEngine.SceneManagement;
public class SceneLoader:MonoBehaviour
{
    
    public  void LoadScene(SceneName sceneName)
    {
        
        MainContainer.PopUpManager.RequestPopup(MainContainer.PrefabContainer.LoadingCanvas);
        SceneManager.LoadSceneAsync((int) sceneName);
    }
}

namespace SceneLoaderManager
{
    public enum SceneName
    {
        Core=0,
        
    }
}
