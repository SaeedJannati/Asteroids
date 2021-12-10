using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthCell : MonoBehaviour
{
  #region  Fields

  [SerializeField] private Image healthImage;


  #endregion

  #region Methods

  public void SetColor(Color colour)
  {
    healthImage.color = colour;
  }

  #endregion
}
