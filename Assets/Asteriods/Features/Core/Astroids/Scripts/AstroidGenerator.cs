using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstroidFeatures;
using Random = UnityEngine.Random;

public class AstroidGenerator : MonoBehaviour
{
   #region Fields

   [SerializeField] private AstroidGeneratorModel config;
   private Transform mTransform;
   private const float deltaPos = 200.0f;

   #endregion

   #region Monobehaviour callBacks

   private void Awake()
   {
      mTransform = transform;
   }

   private void Start()
   {
      StartCoroutine(PopulateAstroids());
      
   }

   #endregion

   #region Methods

   public void OnAstroidDeath()
   {
      StartCoroutine(CreateNewAstroidWithSomeDelay());
   }

   void CreateAstroid()
   {
      var speed = Vector2.zero;
      speed.x = Random.Range(config.minSpeed, config.maxSpeed);
      speed.y = Random.Range(config.minSpeed, config.maxSpeed);
      var isrotating = false;
      var rotSpeed = 0.0f;
      if (Random.Range(0, 100) <= config.rotatingChance)
      {
         isrotating = true;
        rotSpeed = Random.Range(config.minRotSpeed, config.maxRotSpeed);
      }

    
      var size = Random.Range(0, (int) AstroidSize.END);
      var initPos = GetRandomPosOutSideScreen();
      if (ObjectPool.Instantiate(config.astroidsData[size].astroidPrefab, mTransform).TryGetComponent
         (out AstroidMovement astroid))
      {
         astroid.Initialize
            (initPos,speed,rotSpeed,isrotating,config.spriteContainer.GetRandomSprite(),size);
      }


   }

   Vector3 GetRandomPosOutSideScreen()
   {
      var posX = Random.Range
         (MainContainer.MovementConfinment.LeftLimit, MainContainer.MovementConfinment.RitghLimit);
      var posY= Random.Range
         (MainContainer.MovementConfinment.DownLimit, MainContainer.MovementConfinment.UpLimit);

      var randomValue = Random.Range(0, 3);
      var isOutside=false;
      if ( randomValue== 1)
      {
         posX = MainContainer.MovementConfinment.LeftLimit - deltaPos;
         isOutside = true;
      }
      else if(randomValue==2)
      {
         posX = MainContainer.MovementConfinment.RitghLimit + deltaPos;
         isOutside = true;
      }
      randomValue = Random.Range(0, 3);
      if ( randomValue== 1)
      {
         posY = MainContainer.MovementConfinment.DownLimit - deltaPos;
         isOutside = true;
      }
      else if(randomValue==2)
      {
         posY = MainContainer.MovementConfinment.UpLimit + deltaPos;
         isOutside = true;
      }
      if(!isOutside)
         posY = MainContainer.MovementConfinment.UpLimit + deltaPos;
      return  new Vector3(posX,posY,0);
   }

   #endregion

   #region  Coroutines

   IEnumerator CreateNewAstroidWithSomeDelay()
   {
      var delay = Random.Range(config.minDelayPeriod, config.maxdelayPeriod);
      yield return  new WaitForSeconds(delay);
      CreateAstroid();
   }

   IEnumerator PopulateAstroids()
   {
      var delay=new WaitForSeconds(1.0f);
      for (int i = 0; i < config.initAstroidCount; i++)
      {
         CreateAstroid();
         yield return delay;
      }

      var periodDelay = new WaitForSeconds(config.increasePeriodInSeconds);
      while (true)
      {
         yield return periodDelay;
         for (int i = 0; i < config.initAstroidCount;i++)
         {
            CreateAstroid();
            yield return delay;
         }
      }
   }

   #endregion


}
