using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreContainer : MonoBehaviour
{
  #region fields

  [SerializeField] private SpaceShipMovementLogic spaceShipMovementLogic;
  [SerializeField] private PlayerInputLogic playerInputLogic;
  [SerializeField] private MovementConfinementLogic movementConfinemetLogic;
  [SerializeField] private AstroidGenerator astroidGenerator;
  [SerializeField] private ScoreLogic scoreLogic;
  [SerializeField] private PlayerHealthLogic healthLogic;
  [SerializeField] private CameraShakeLogic cameraShakeLogic;
  [SerializeField] private PopUpManager popupManager;
  [SerializeField] private SceneLoader sceneLoader;
  [SerializeField] private GameManger gameManager;
  private const string prefabContainreAdderss = "Containers/PrefabContainer";
  #endregion

  #region MonobehaviourCallbacks

  private void Awake()
  {
    InjectDependencies();
  }

  #endregion

  #region Mehtods

  void InjectDependencies()
  {
    InjectPrefabContainer();
    MainContainer.InjectSpaceShipMovementLogic(spaceShipMovementLogic);
    MainContainer.InjectPlayerInputLogic(playerInputLogic);
    MainContainer.InjectMoveConfinment(movementConfinemetLogic);
    MainContainer.InjectAstroidGenerator(astroidGenerator);
    MainContainer.InjectScoreLogic(scoreLogic);
    MainContainer.InjectPlayerHealthLogic(healthLogic);
    MainContainer.InjectCameraShakeLogic(cameraShakeLogic);
    MainContainer.InjectPopUpManager(popupManager);
    MainContainer.InjectSceneLoader(sceneLoader);
    MainContainer.InjectGameManager(gameManager);
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
