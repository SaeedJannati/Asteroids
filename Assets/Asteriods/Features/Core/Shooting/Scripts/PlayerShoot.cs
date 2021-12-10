using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  #region  Fields

  [SerializeField] PlayerShootModel config;



  [SerializeField] Transform MuzzleTransform;
  [SerializeField] private ParticleSystem shootEffect;
  [SerializeField] private Transform spaceShipTransform;
  private float lastShotTime;
  private Vector3 shakeDestPos;
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
      PlayShootEffects();
     
    }
  }

  void PlayShootEffects()
  {
    shootEffect.Play();
    PlayShootRecoil();
  }

  void PlayShootRecoil()
  {
    lastShotTime = Time.time;
    shakeDestPos=Vector3.zero;
    shakeDestPos.y = -.05f;
    spaceShipTransform.DOLocalMove(shakeDestPos, .03f).onComplete+= () =>
    {
      shakeDestPos.y = 0;
      spaceShipTransform.DOLocalMove(shakeDestPos, .03f);
    };
  }

  #endregion
}
