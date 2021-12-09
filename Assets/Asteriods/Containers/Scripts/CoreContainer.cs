using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreContainer : MonoBehaviour
{
  #region fields

  [SerializeField] private SpaceShipMovementLogic spaceShipMovementLogic;
  [SerializeField] private PlayerInputLogic playerInputLogic;

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
    MainContainer.InjectSpaceShipMovementLogic(spaceShipMovementLogic);
    MainContainer.InjectPlayerInputLogic(playerInputLogic);
  }

  #endregion
}
