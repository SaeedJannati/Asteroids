using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScorePrefs 
{
   #region Fields

   #region Keys

   private static readonly string high_score_key = "player_high_score";


   #endregion

   #endregion

   #region Properties

   public static int HighScore
   {
      get => PlayerPrefs.GetInt(high_score_key, 0);
      set => PlayerPrefs.SetInt(high_score_key, value);

   }

   #endregion
   #region Methods

   #region HighScore

   public static void ClearHighScore()
   {
      if(!PlayerPrefs.HasKey(high_score_key))
         return;
      PlayerPrefs.DeleteKey(high_score_key);
   }

   #endregion

   #endregion
}
