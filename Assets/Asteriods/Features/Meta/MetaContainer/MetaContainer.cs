using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaContainer : MonoBehaviour
{
    #region Fields
    private const string prefabContainreAdderss = "Containers/PrefabContainer";
    [SerializeField] private PopUpManager popupManager;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private ScoreLogic scoreLogic;
    [SerializeField] private MetaMainMenuLogic mainMenulogic;
    [SerializeField] private AudioManager audioManager;

    #endregion

    #region MonobehaviourCallBacks

    private void Awake()
      {
        InjectDependencies();
      }

    #endregion

    #region Methods
    void InjectDependencies()
    {
        InjectPrefabContainer();
        MainContainer.InjectScoreLogic(scoreLogic);
        MainContainer.InjectPopUpManager(popupManager);
        MainContainer.InjectSceneLoader(sceneLoader);
        MainContainer.InjectMetaMainMenu(mainMenulogic);
        MainContainer.InjectAudioManager(audioManager);
    }
    
    public void InjectPrefabContainer()
    {
        if(MainContainer.PrefabContainer!=null)
            return;
        var request = Resources.LoadAsync<PrefabContainer>(prefabContainreAdderss);
        request.completed += (asynoptration) =>
        {
            MainContainer.InjectPrefabContainer((PrefabContainer)request.asset);
        };
    }
    #endregion
    
}
