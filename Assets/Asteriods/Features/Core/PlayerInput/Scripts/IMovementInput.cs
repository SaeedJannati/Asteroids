using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementInput 
{
    Vector2 Direction {  get; }
    Action ShootAction { get; set; }


}
