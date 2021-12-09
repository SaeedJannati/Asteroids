using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayeInputModel", menuName = "Asteriods/Input/PCModel" )]
public class PlayerInputPcModel : ScriptableObject
{
   public KeyCode shootKey;
   public KeyCode upKey;
   public KeyCode downKey;
   public KeyCode rightKey;
   public KeyCode leftkey;

}
