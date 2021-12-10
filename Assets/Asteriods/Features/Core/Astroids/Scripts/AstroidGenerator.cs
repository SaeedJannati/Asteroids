using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstroidFeatures;
using Sirenix.OdinInspector;
using Random = UnityEngine.Random;

public class AstroidGenerator : MonoBehaviour
{
   #region Fields

   [SerializeField] private AstroidGeneratorModel config;
   private Transform mTransform;
   private const float deltaPos = 200.0f;
   [SerializeField]  private int astroidCount;
  [SerializeField] private int astroidsAlive;
  public static event Action OnClearTheScreen;
  public static event Action OnGameStarted;

  private bool isCleared;
   #endregion

   #region Properties

   public GameObject ExplosionPrefab
   {
      get => config.astoirdExplosion;
   }


   #endregion
   #region Monobehaviour callBacks

   private void Awake()
   {
      mTransform = transform;
   }

   private void Start()
   {
      PopulateAstroids();
      
   }

   #endregion

   #region Methods



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
      if(isCleared)
         return;
      if (ObjectPool.Instantiate(config.astroidsData[size].astroidPrefab, mTransform).TryGetComponent
         (out AstroidMovement astroid))
      {
         astroid.Initialize
            (initPos,speed,rotSpeed,isrotating,config.spriteContainer.GetRandomSprite(),size);
      }

      astroidsAlive++;

   }

  public void  CreateAstroids(Vector3 positon, AstroidSize Size,int count,Sprite sprite)
   {
      var speed = Vector2.zero;
      speed.x = Random.Range(config.minSpeed, config.maxSpeed);
      speed.y = Random.Range(config.minSpeed, config.maxSpeed);
      var currentSpeed = speed;
      var deltaAngle = Mathf.PI * 2.0f / count;
      var isrotating = false;
      var rotSpeed = 0.0f;
     
      if (Random.Range(0, 100) <= config.rotatingChance)
      {
         isrotating = true;
         rotSpeed = Random.Range(config.minRotSpeed, config.maxRotSpeed);
      }

    
      var size = (int)Size-1;
      
      var initPos = positon;
      for (int i = 0; i < count; i++)
      {
         if(isCleared)
            return;
         currentSpeed = RotateVectorByAngle(speed,i * deltaAngle);
         if (ObjectPool.Instantiate(config.astroidsData[size].astroidPrefab, mTransform).TryGetComponent
            (out AstroidMovement astroid))
         {
            astroid.Initialize
               (initPos, currentSpeed, rotSpeed, isrotating,sprite , size);
         }
         astroidsAlive++;
      }
   }

  Vector2 RotateVectorByAngle(Vector2 vector,float angle)
  {
     if (angle == 0)
        return vector;
     var length = vector.magnitude;
     var outPut = Vector2.one;
     var initAngle = Mathf.Atan(vector.y / vector.x);
     angle += initAngle;
     outPut.x = length * (Mathf.Cos(angle));
     outPut.y=length * (Mathf.Sin(angle));
     return outPut;
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

   public AstroidData GetAstroidData(AstroidSize size)
   {
      return config.astroidsData[(int) size];
   }


   public void OnAstroidDie()
   {
      astroidsAlive--;
      if (astroidsAlive < astroidCount)
         StartCoroutine(CreateNewAstroidWithSomeDelay());
   }
    [Button]
   public void ClearAllAStroids()
   {
      isCleared = true;
      StopAllCoroutines();
      OnClearTheScreen?.Invoke();

   
      astroidsAlive = 0;
      astroidCount = config.initAstroidCount;
   
      
   }

  public void PopulateAstroids()
  {
     isCleared = false;
      StartCoroutine(PopulateAstroidsCoroutine());

   }

   #endregion

   #region  Coroutines

   IEnumerator CreateNewAstroidWithSomeDelay()
   {
      var delay = Random.Range(config.minDelayPeriod, config.maxdelayPeriod);
      yield return  new WaitForSeconds(delay);
      CreateAstroid();
   }

   IEnumerator PopulateAstroidsCoroutine()
   {
      var delay=new WaitForSeconds(1.0f);
      astroidCount = 0;
      for (int i = 0; i < config.initAstroidCount; i++)
      {
         CreateAstroid();
         astroidCount++;
         yield return delay;
      }

    
      var periodDelay = new WaitForSeconds(config.increasePeriodInSeconds);
      while (true)
      {
         yield return periodDelay;
         for (int i = 0; i < config.initAstroidCount;i++)
         {
            CreateAstroid();
            astroidCount++;
            yield return delay;
         }
      }
   }

   #endregion


}
