using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContainer 
{
  #region  Fields

  private static SpaceShipMovementLogic _spaceShipMovement;
  private static IMovementInput movementInput;
  private static PlayerInputLogic _playerInput;
  private static MovementConfinementLogic movementConfinmentLogic;


  #endregion

  #region  properties

  public static SpaceShipMovementLogic SpaceShipMovement
  {
      get =>_spaceShipMovement;
  }

  public static IMovementInput MovementInput
  {
      get => movementInput;
  }

  public static PlayerInputLogic PlayerInput
  {
      get => _playerInput;
  }

  public static MovementConfinementLogic MovementConfinment
  {
      get => movementConfinmentLogic;
  }

  #endregion

  #region  Mehtodes

  public static void InjectSpaceShipMovementLogic(SpaceShipMovementLogic logic)
  {
      _spaceShipMovement = logic;
  }

  public static void InjectMovementInput(IMovementInput input)
  {
      movementInput = input;
  }

  public static void InjectPlayerInputLogic(PlayerInputLogic inputLogic)
  {
      _playerInput = inputLogic;
  }

  public static void InjectMoveConfinment(MovementConfinementLogic logic)
  {
      movementConfinmentLogic = logic;
  }

  #endregion
}
