using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstroidFeatures;
using Random = UnityEngine.Random;

public class AstroidMovement : ConfinedMovementBase
{
    #region Fields

  [SerializeField]  private float xSpeed;
  [SerializeField]  private float ySpeed;
  [SerializeField]  private float rotSpeed;
  [SerializeField]   private bool isRotating;
    

    #endregion


    #region methods

    public void Initialize(Vector3 initPos, Vector2 speed, float RotSpeed, bool IsRotating,Sprite sprite,int Size)
    {
        mTransform.position = initPos;
        isRotating = IsRotating;
        xSpeed = speed.x;
        ySpeed = speed.y;
        rotSpeed = RotSpeed;
        mainRenderer.sprite = sprite;
      
        if(TryGetComponent(out AstroidHealth health))
        {
            health.Initialize((AstroidSize) Size,sprite);
        }
        StartCoroutine(MoveCoroutine());
    }

    int GetRandomSign()
    {
        var outPut = Random.Range(0, 2);
        outPut = outPut > 0 ? -1 : 1;
        return outPut;
    }

    #endregion

    #region Coroutines

    IEnumerator MoveCoroutine()
    {
        yield return null;
        var deltaPos = Vector3.zero;
        var perpendicularUnit = new Vector3(0, 0, 1);
        xSpeed *= GetRandomSign();
        ySpeed *= GetRandomSign();
        rotSpeed *= GetRandomSign();
        while (true)
        {
            deltaPos.x = xSpeed * Time.deltaTime;
            deltaPos.y = ySpeed * Time.deltaTime;
            mTransform.position += deltaPos;
            if (isRotating)
                mTransform.Rotate(perpendicularUnit, rotSpeed * Time.deltaTime);
            CheckIfOutsideScreen();
            yield return null;
        }
    }

    #endregion
}