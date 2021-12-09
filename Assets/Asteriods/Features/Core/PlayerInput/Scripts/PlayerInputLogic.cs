using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputLogic : MonoBehaviour
{
  #region  Fields

  [SerializeField]private PlayerInputLogicModel config;
  private IMovementInput movementInput;

  #endregion

  #region  Monobehaviour Callbacks

  private void Start()
  {
    var inputObj = Instantiate(config.GetCurrentPaltform());
    if (inputObj.TryGetComponent(out movementInput))
    {
      MainContainer.InjectMovementInput(movementInput);
    }
  }

  private void Update()
  {
    
    MainContainer.SpaceShipMovement.ApplyForce(movementInput.Direction.x,movementInput.Direction.y);
  }

  #endregion

  #region Methods

  

  #endregion
}
