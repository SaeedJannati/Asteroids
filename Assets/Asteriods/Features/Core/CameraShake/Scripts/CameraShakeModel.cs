using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CameraShakeModel", menuName = "Asteriods/Core/CameraShake" )]
public class CameraShakeModel : ScriptableObject
{
   public int vibratition;
   public float intensity;
   public float period;
}
