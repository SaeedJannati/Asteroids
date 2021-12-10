using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShakeLogic : MonoBehaviour
{
   #region Fields

   [SerializeField] private CameraShakeModel config;
   private Transform mTransform;
   #endregion

   #region  MonobehaviourCallbacks

   private void Awake()
   {
      mTransform = transform;
   }

   #endregion
   #region Methods

   public void Shake()
   {
      mTransform.DOShakePosition(config.intensity, config.period, config.vibratition);
   }

   #endregion
}
