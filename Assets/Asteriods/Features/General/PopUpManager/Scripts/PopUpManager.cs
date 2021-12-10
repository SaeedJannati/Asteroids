using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    #region  Fields

    private Transform mTransform;
    

    #endregion

    #region  Monobehaviour callbacks

    private void Awake()
    {
        mTransform = transform;
    }

    #endregion

    #region Methods

    public  BasePopup RequestPopup(string popupPath)
    {
        var obj = Resources.Load<GameObject>(popupPath) ;
        Instantiate(obj, mTransform).TryGetComponent(out BasePopup popUp);
        return popUp;

    }

    #endregion
}
