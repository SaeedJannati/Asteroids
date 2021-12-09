using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceShip Movement", menuName = "Asteriods/SpaceShip/Movement/Model")]
public class SpaceShipMevementModel : ScriptableObject
{

    #region Fields

    public float maxSpeedX;
    public float maxSpeedY;

    public float yAcceleration;
    public float xAcceleration;

    #endregion

    #region  Methods

    
    [Button]
    public void PrintJsonToConsole()
    {
        Debug.Log(JsonConvert.SerializeObject(this));
    }
    #endregion
    
   
}
