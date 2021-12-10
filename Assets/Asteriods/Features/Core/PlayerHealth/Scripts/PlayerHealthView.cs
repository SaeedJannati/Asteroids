using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour
{
   #region Fields

   [SerializeField] private PlayerHealthViewModel config;
   private Transform mTransform;

   private List<HealthCell> healthCells;
   #endregion

   #region MonobehaviourCallback

   private void Awake()
   {
      mTransform = transform;
   }

   #endregion

   #region Methods

   public void Initialize()
   {
      healthCells=new List<HealthCell>(MainContainer.PlayerHealthLogic.GetMaxhHealth);
      for (int i = 0; i < MainContainer.PlayerHealthLogic.GetMaxhHealth; i++)
      {
         if (GameObject.Instantiate(config.healthPrefab).TryGetComponent(out HealthCell cell))
         {
            cell.SetColor(config.activeColour);
            healthCells.Add(cell);
         }

      }
   }

   #endregion


}
