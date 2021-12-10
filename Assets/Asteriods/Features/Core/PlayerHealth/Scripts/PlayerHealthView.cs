using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour
{
   #region Fields

   [SerializeField] private PlayerHealthViewModel config;
   private Transform mTransform;

   private List<HealthCellStatus> healthCells;
   #endregion

   #region MonobehaviourCallback

   private void Awake()
   {
      mTransform = transform;
   }

   private void OnEnable()
   {
      PlayerHealthLogic.OnHealthChange += DecreaseHealth;
   }

   private void OnDisable()
   {
      PlayerHealthLogic.OnHealthChange-= DecreaseHealth;
   }

   private void Start()
   {
      Initialize();
   }

   #endregion

   #region Methods

   public void Initialize()
   {
      healthCells=new List<HealthCellStatus>(MainContainer.PlayerHealthLogic.GetMaxhHealth);
      for (int i = 0; i < MainContainer.PlayerHealthLogic.GetMaxhHealth; i++)
      {
         if (Instantiate(config.healthPrefab,transform).TryGetComponent(out HealthCell cell))
         {
            cell.SetColor(config.activeColour);
            healthCells.Add(new HealthCellStatus(cell));
         }

      }
   }

   public void DecreaseHealth(int dummyInput)
   {
      for (int i = healthCells.Count-1; i >=0; i--)
      {
         if(healthCells[i].isGrayedOut)
            continue;
         healthCells[i].cell.SetColor(config.deactiveColour);
         healthCells[i].isGrayedOut = true;
         return;
      }
   }

   #endregion

   #region  LocalCalsses

   [Serializable]
   public class HealthCellStatus
   {
      public HealthCell cell;
      public bool isGrayedOut;

      public HealthCellStatus (HealthCell Cell)
      {
         cell = Cell;
         isGrayedOut = false;
      }
   }



#endregion

  

}
