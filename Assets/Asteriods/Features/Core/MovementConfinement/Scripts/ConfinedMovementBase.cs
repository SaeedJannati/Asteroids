using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfinedMovementBase : MonoBehaviour
{
    protected Transform mTransform;
    [SerializeField] private SpriteRenderer mainRenderer;

    private void Awake()
    {
        mTransform = transform;
    }

    protected void CheckIfOutsideScreen()
    {
        var currentY = mTransform.position.y;
        var currentX = mTransform.position.x;
        var destX=currentX;
        var destY = currentY;
        var isItOutside = false;
        if (currentY < MainContainer.MovementConfinment.DownLimit)
        {
            isItOutside = true;
            destY = MainContainer.MovementConfinment.UpLimit;
        }

        if (currentY > MainContainer.MovementConfinment.UpLimit)
        {
            isItOutside = true;
            destY = MainContainer.MovementConfinment.DownLimit;
        }

        if (currentX > MainContainer.MovementConfinment.RitghLimit)
        {
            isItOutside = true;
            destX = MainContainer.MovementConfinment.LeftLimit;
        }

        if (currentX < MainContainer.MovementConfinment.LeftLimit)
        {
            isItOutside = true;
            destX = MainContainer.MovementConfinment.RitghLimit;
        }

        if (!isItOutside)
            return;
        if(mainRenderer.isVisible)
            return;
        mTransform.position=new Vector3(destX,destY,0);
         
    }
}
