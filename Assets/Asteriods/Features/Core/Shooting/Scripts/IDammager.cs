using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDammager 
{
  int Damage { get; }
  bool CanDammagePlayer { get; }
  bool CanDammageEnemy { get; }

}
