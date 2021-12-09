using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerShootModel", menuName = "Asteriods/SpaceShip/PlayerShoot" )]
public class PlayerShootModel : ScriptableObject
{
    public float recoilTime;
    public GameObject bulletPrefab;
}
