using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovementLogic : MonoBehaviour
{
   #region  Fields

   private SpaceShipMevementModel config;
   private Vector3 currentSpeed=new Vector3();

   private Transform mTrtansform=null;

   private Vector3 position=new Vector3();
   #endregion

   #region Monbehaviour callbacks

   private void Awake()
   {
      mTrtansform = GetComponent<Transform>();
   }

   #endregion

   #region Methods


   public void ApplyForce(float xAcceleration,float yAcceleration)
   {
      CalculateSpeed(xAcceleration, yAcceleration);
      Move();
   }

   void CalculateSpeed(float xAcceleration,float yAcceleration)
   {
      xAcceleration *= Time.deltaTime * config.xAcceleration;
      yAcceleration *= Time.deltaTime * config.yAcceleration;
      currentSpeed.x += xAcceleration;
      currentSpeed.y += yAcceleration;
      currentSpeed.z = 0;
      currentSpeed.x = Mathf.Clamp(currentSpeed.x, -config.maxSpeedX, config.maxSpeedX);
      currentSpeed.y = Mathf.Clamp(currentSpeed.y, -config.maxSpeedY, config.maxSpeedY);
   }

   void Move()
   {
      position = mTrtansform.position;
      position += currentSpeed * Time.deltaTime;
      
   }
   #endregion

   #region Coroutines



   #endregion
}
