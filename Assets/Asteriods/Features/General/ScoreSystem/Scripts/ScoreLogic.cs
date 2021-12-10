using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
   #region  Fields

  
 [SerializeField]  private int currentScore;

 public static event Action<int> OnScoreChange; 
   #endregion

   #region  MonobehaviourCallbacks

   private void OnEnable()
   {
      PlayerHealthLogic.OnGameEnd += CheckForNewHighScore;
   }

   private void Start()
   {
      ResetGame();
   }

   private void OnDisable()
   {
      PlayerHealthLogic.OnGameEnd -= CheckForNewHighScore;
   }

   #endregion

   #region  Methods

   public void AddScore(int deltaScore)
   {
      currentScore += deltaScore;
      OnScoreChange?.Invoke(currentScore);
   }

   public int GetHighScore()
   {
      return ScorePrefs.HighScore;
   }
   

   void CheckForNewHighScore()
   {
      if (currentScore > ScorePrefs.HighScore)
      {
         ScorePrefs.HighScore = currentScore;
      }
      
   }

   void ResetGame()
   {
      CheckForNewHighScore();
      currentScore = 0;
   }

   #endregion
}
