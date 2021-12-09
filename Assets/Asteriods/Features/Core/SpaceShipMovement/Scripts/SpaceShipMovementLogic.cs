using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovementLogic : ConfinedMovementBase
{
   #region  Fields

  [SerializeField] private SpaceShipMevementModel config;
   private Vector3 currentSpeed=new Vector3();


   private Vector3 position;



   private Quaternion destRot;
   private Vector3 moveDirection;
   #endregion

   private void Start()
   {
      currentSpeed=Vector3.zero;
   }

   #region Methods


   public void ApplyForce(float xAcceleration,float yAcceleration)
   {
      CalculateSpeed(xAcceleration, yAcceleration);
      Move();
      RotateTowardMoveDirection();
      
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
      // mTransform.Translate(currentSpeed * Time.deltaTime);
      position = mTransform.position;
      position += currentSpeed * Time.deltaTime;
      position.z = 0;
      mTransform.position = position;
      CheckIfOutsideScreen();

   }

   void RotateTowardMoveDirection()
   {

   moveDirection = currentSpeed.normalized;
   destRot = Quaternion.LookRotation(Vector3.forward, moveDirection);
   mTransform.rotation =
         Quaternion.RotateTowards(
            mTransform.rotation, 
            destRot, 
            config.roataionSpeed * Time.deltaTime);
   }

   #endregion

   #region Coroutines



   #endregion


}
