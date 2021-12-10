using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputHud : MonoBehaviour, IMovementInput
{
    [SerializeField] private Dpad moveDpad;
    private Action shootAction;
    private Vector2 direction;

    
    [SerializeField] bool isMouseDown;

    public Vector2 Direction
    {
        get => GetDpadDirection();
    }

    public Action ShootAction
    {
        get => shootAction;
        set => shootAction = value;
    }

    Vector2 GetDpadDirection()
    {
        direction.x = moveDpad.Direction.x;
        direction.y = moveDpad.Direction.z;
        direction = direction.normalized;
        return direction;
    }

    public void Shoot()
    {
        shootAction?.Invoke();
    }
    
    public void OnPointerDown()
    {
        isMouseDown = true;
        StartCoroutine(continousShootCoroutine());
    }
    public void OnPointerUp()
    {
        isMouseDown = false;
    }
    public void OnPointerExit()
    {
        isMouseDown = false;
    }
    public void ContinuesShoot()
    {
        if (!isMouseDown)
            return;
        Shoot();
    }
    
    IEnumerator continousShootCoroutine()
    {
        while (isMouseDown)
        {
            ContinuesShoot();
            yield return null;
        }
    }
}