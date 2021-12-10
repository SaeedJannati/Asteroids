using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHudLogic : MonoBehaviour
{
    #region Fields

    

    #endregion

    #region Methods

    public void BringMenuUp()
    {
        var popUp = MainContainer.PopUpManager.RequestPopup(MainContainer.PrefabContainer.CoreMenu);
        ((CoreMenuPopup)popUp).BringUp(false);
    }

    #endregion
}
