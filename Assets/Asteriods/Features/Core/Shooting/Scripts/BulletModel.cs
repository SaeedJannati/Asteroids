using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletModel", menuName = "Asteriods/SpaceShip/Bullet" )]
public class BulletModel : ScriptableObject
{
    public float lifeTime = 3.0f;
    public  float velocity = 20.0f;
    public int damage =1;
    public bool canDammageEnemies;
    public  Sprite sprite;
}
