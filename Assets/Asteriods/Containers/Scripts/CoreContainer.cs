using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreContainer : MonoBehaviour
{
  #region fields

  [SerializeField] private SpaceShipMovementLogic spaceShipMovementLogic;


  #endregion

  #region MonobehaviourCallbacks

  private void Start()
  {
    InjectDependencies();
  }

  #endregion

  #region Mehtods

  void InjectDependencies()
  {
    MainContainer.InjectSpaceShipMovementLogic(spaceShipMovementLogic);
  }

  #endregion
}
