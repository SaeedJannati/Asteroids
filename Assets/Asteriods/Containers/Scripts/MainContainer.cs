using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContainer 
{
  #region  Fields

  private static SpaceShipMovementLogic spaceShipMovementLogic;
  private static IMovementInput movementInput;
  private static PlayerInputLogic playerInputLogic;

  #endregion

  #region  properties

  public static SpaceShipMovementLogic SpaceShipMovementLogic
  {
      get =>spaceShipMovementLogic;
  }

  public static PlayerInputLogic PlayerInputLogic
  {
      get => playerInputLogic;
  }
  public static IMovementInput MovementInput;
  #endregion

  #region  Mehtodes

  public static void InjectSpaceShipMovementLogic(SpaceShipMovementLogic logic)
  {
      spaceShipMovementLogic = logic;
  }

  public static void InjectMovementInput(IMovementInput input)
  {
      movementInput = input;
  }

  public static void InjectPlayerInputLogic(PlayerInputLogic inputLogic)
  {
      playerInputLogic = inputLogic;
  }

  #endregion
}
