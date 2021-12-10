using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerHealthModel", menuName = "Asteriods/SpaceShip/PlayerHealth" )]
public class PlayerHealthModel : ScriptableObject
{
  #region  Fields

  public int initHealth;
  public GameObject explosionPrefab;
  public int invulnarablePeriod;
  

  #endregion
}
