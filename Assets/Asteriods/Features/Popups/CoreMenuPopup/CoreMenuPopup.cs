using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CoreMenuPopup : BasePopup
{
   #region Fields

   [SerializeField] private GameObject closeButton;
   [SerializeField] private GameObject continueButton;
   [SerializeField] private GameObject scoreSection;
   [SerializeField] private TMP_Text highScoreText;
   [SerializeField] private TMP_Text scoreText;
   

   #endregion

   #region Monobehaviour callbacks

   private void OnEnable()
   {
      Time.timeScale = 0;
   }

   private void OnDisable()
   {
      Time.timeScale = 1;
   }

   #endregion

   #region Methods

   public void BringUp(bool isGameOver)
   {
      scoreSection.SetActive(isGameOver);
      closeButton.SetActive(!isGameOver);
      continueButton.SetActive(!isGameOver);
      if (isGameOver)
      {
         FillTheScoreTexts();
      }
   }

   void FillTheScoreTexts()
   {
      highScoreText.text=MainContainer.ScoreLogic.GetHighScore().ToString();
      scoreText.text = MainContainer.ScoreLogic.GetScore().ToString();
   }

   public void Close()
   {
      Destroy(gameObject);
   }

   public void RestartGame()
   {
      
      MainContainer.GameManger.ResetGame();
         Destroy(gameObject);
   }

   public void Exit()
   {
      MainContainer.GameManger.ReturnToCore();
   }

   #endregion
}
