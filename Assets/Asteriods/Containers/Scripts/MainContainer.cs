using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContainer 
{
  #region  Fields

  private static SpaceShipMovementLogic spaceShipMovementLogic=null;
  
  

  #endregion

  #region  properties

  public static SpaceShipMovementLogic SpaceShipMovementLogic
  {
      get =>spaceShipMovementLogic;
  }

  #endregion

  #region  Mehtodes

  public static void InjectSpaceShipMovementLogic(SpaceShipMovementLogic logic)
  {
      spaceShipMovementLogic = logic;
  }


  #endregion
}
