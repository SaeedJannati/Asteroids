using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InputLogic;
[CreateAssetMenu(fileName = "PlayeInputModel", menuName = "Asteriods/Input/LogicModel")]
public class PlayerInputLogicModel : ScriptableObject
{
    #region  Fields

    public Platform platform;
    
    public  List<InputPrefab>  playformInputs;


   #endregion



   #region Methods

  public GameObject GetCurrentPaltform()
   {
       var output = playformInputs.FirstOrDefault(item => item.platform == platform); 
       return output?.inputPrefab;
   }


   #endregion


}

namespace InputLogic
{
    #region Enums

    [System.Serializable]
    public enum Platform
    {
        PC,
        MOBILE
    }

    [System.Serializable]
    public class InputPrefab
    {
        public Platform platform;
        public GameObject inputPrefab;
    }

    #endregion
}
