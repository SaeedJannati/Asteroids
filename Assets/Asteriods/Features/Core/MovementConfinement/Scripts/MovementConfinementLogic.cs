using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MovementConfinementLogic : MonoBehaviour
{
  #region  Fields

  private float leftLimit;
  private float rightLimit;
  private float upLimit;
  private float downlimit;

  #endregion

  #region  Properties

  public float LeftLimit
  {
    get => leftLimit;
  }
  public float RitghLimit
  {
    get => rightLimit;
  }

  public float UpLimit
  {
    get => upLimit;
  }

  public float DownLimit
  {
    get => downlimit;
  }

  #endregion
  #region MonoBehaviorCallbacks

  private void Start()
  {
    CalculateLimits();
  }

  #endregion

  #region Mehtods
[Button]
 public void CalculateLimits()
  {
    var mainCam = Camera.main;
    var topRightPoint = mainCam.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth, mainCam.pixelHeight, 0));
    var bottomLeft = mainCam.ScreenToWorldPoint(Vector3.zero);
    leftLimit = bottomLeft.x;
    downlimit = bottomLeft.y;
    rightLimit = topRightPoint.x;
    upLimit = topRightPoint.y;
  }

  #endregion
}
