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
  private static AstroidGenerator astroidGenerator;
  private static ScoreLogic scoreLogic;
  private static PlayerHealthLogic playerHealthLogic;
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

  public static AstroidGenerator AstroidGenerator
  {
      get => astroidGenerator;
  }

  public static ScoreLogic ScoreLogic
  {
      get => scoreLogic;
  }

  public static PlayerHealthLogic PlayerHealthLogic
  {
      get => playerHealthLogic;
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

  public static void InjectAstroidGenerator(AstroidGenerator generator)
  {
      astroidGenerator = generator;
  }

  public static void InjectScoreLogic(ScoreLogic logic)
  {
      scoreLogic = logic;
  }

  public static void InjectPlayerHealthLogic(PlayerHealthLogic logic)
  {
      playerHealthLogic = logic;
  }

  #endregion
}
