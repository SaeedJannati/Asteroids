using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerHealthViewModel", menuName = "Asteriods/UI/PlayerHealthView" )]
public class PlayerHealthViewModel : ScriptableObject
{
    public GameObject healthPrefab;
    public Color activeColour;
    public Color deactiveColour;
}
