using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreViewCore : MonoBehaviour
{
    #region Fields

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField]  private TMP_Text HighScorText;
    private int TargetScore;
    private int currentScore;
    private bool isUpdating;
    WaitForSeconds delay=new WaitForSeconds(.03f);
    #endregion

    #region MonobehaviourCallbacks

    private void OnEnable()
    {
        ScoreLogic.OnScoreChange += UpdateScore;
    }

    IEnumerator  Start()
    {
        yield return null;
        GameStart();
    }

    private void OnDisable()
    {     
        ScoreLogic.OnScoreChange -= UpdateScore;
        
    }

    #endregion

    #region Methods

    void GameStart()
    {
        currentScore = 0;
        ScoreText.text = currentScore.ToString();
        HighScorText.text= MainContainer.ScoreLogic.GetHighScore().ToString();
        isUpdating = false;
    }

    void UpdateScore(int score)
    {
        TargetScore = score;
        if(isUpdating)
            return;
        StartCoroutine(UpdateScoreCoroutine());
    }

    #endregion

    #region Coroutines

    IEnumerator UpdateScoreCoroutine()
    {
        isUpdating = true;
        while (currentScore<TargetScore)
        {
            currentScore++;
            ScoreText.text = currentScore.ToString();
            yield return delay;
        }
        isUpdating = false;
    }


    #endregion
}
