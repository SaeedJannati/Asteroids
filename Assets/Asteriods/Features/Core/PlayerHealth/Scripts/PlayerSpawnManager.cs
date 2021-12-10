using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using  TMPro;

public class PlayerSpawnManager : MonoBehaviour
{
  #region  Fields

  private int respawnTime = 3;
  [SerializeField] TMP_Text counterText;
  WaitForSeconds delay=new WaitForSeconds(.3f);

  #endregion
  #region  Monobehaviour Callbacks

  private void OnEnable()
  {
    
    PlayerHealthLogic.OnRespawn += Respawn;
  }

  private void OnDisable()
  {
    PlayerHealthLogic.OnRespawn -= Respawn;
  }

  #endregion

  #region Methods

  public void Respawn(GameObject spaceShip)
  {
    spaceShip.SetActive(false);
    StartCoroutine(RespawnCoroutine(spaceShip));
  }

  #endregion

  #region  Coroutines

  IEnumerator RespawnCoroutine(GameObject spaceShip)
  {

    counterText.gameObject.SetActive(true);
    counterText.alpha = 0;
    for (int i = 0; i < respawnTime; i++)
    {
      counterText.text = (respawnTime - i).ToString();
      
      counterText.DOFade(1, .1f).onComplete += () =>
      {
        counterText.DOScale(1.5f, .3f);
      };
      yield return delay;
      yield return delay;
      counterText.DOFade(0, .15f);
      counterText.transform.localScale=Vector3.one;
      yield return delay;
    }
    counterText.gameObject.SetActive(false);
    counterText.alpha = 1;
    MainContainer.AstroidGenerator.PopulateAstroids();
    spaceShip.transform.position=Vector3.zero;
    spaceShip.transform.rotation = Quaternion.identity;
    spaceShip.SetActive(true);
  }

  #endregion
 
}
