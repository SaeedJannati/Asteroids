using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputPc : MonoBehaviour, IMovementInput
{
    #region Fields

    [SerializeField] private PlayerInputPcModel config;
   [SerializeField] private Vector2 direction;
    private Action shootAction;

    #endregion

    #region Proepeties

    public Vector2 Direction
    {
        get => direction;
    }

    public Action ShootAction
    {
        get => shootAction;
    }

    #endregion

    #region MonobehaviourCallBacks

    void Update()
    {
        CheckForDirections();
        CheckForShooting();
    }

    #endregion

    #region Methods

    void CheckForDirections()
    {
        direction.x = 0;
        direction.y = 0;
        CheckForAxis();
        CheckForDirectionKeys();
        CheckForDircetionLimitaions();
    }

    void CheckForAxis()
    {
        direction.x += Input.GetAxis("Horizontal");
        direction.y += Input.GetAxis("Vertical");
    }

    void CheckForDirectionKeys()
    {
        if (Input.GetKey(config.upKey))
        {
            direction.y += 1;
        }

        if (Input.GetKey(config.downKey))
        {
            direction.y -= 1;
        }

        if (Input.GetKey(config.rightKey))
        {
            direction.x += 1;
        }

        if (Input.GetKey(config.leftkey))
        {
            direction.x -= 1;
        }
    }

    void CheckForDircetionLimitaions()
    {
        direction.x = Mathf.Clamp(direction.x, -1.0f, 1.0f);
        direction.y = Mathf.Clamp( direction.y, -1.0f, 1.0f);
    }

    void CheckForShooting()
    {
        if (Input.GetKeyDown(config.shootKey))
        {
            shootAction?.Invoke();
        }
    }

    #endregion
}