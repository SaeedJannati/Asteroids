using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  #region  Fields

  [SerializeField] PlayerShootModel config;



  [SerializeField] Transform MuzzleTransform;
  private float lastShotTime;

  #endregion

  #region Monobehaviour Callbacks

  private void OnEnable()
  {
    PlayerInputLogic.Shoot += Shoot;
  }

  private void Start()
  {
    lastShotTime = Time.time - config.recoilTime - 1.0f;
  }

  private void OnDisable()
  {
    PlayerInputLogic.Shoot -= Shoot;
  }

  #endregion

  #region Methods

  public void Shoot()
  {
    if (Time.time > lastShotTime + config.recoilTime)
    {
      ObjectPool.Instantiate(config.bulletPrefab, MuzzleTransform.position, MuzzleTransform.rotation);
      lastShotTime = Time.time;
    }
  }

  #endregion

  #region



  #endregion
}
