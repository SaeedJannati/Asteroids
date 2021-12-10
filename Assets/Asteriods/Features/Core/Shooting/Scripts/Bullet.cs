using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDammager
{
    #region Fields

    [SerializeField] Transform mTransform;
    [SerializeField] Rigidbody2D mRigidBody;


    [SerializeField] private BulletModel config;
    [SerializeField] private SpriteRenderer spriteRenderer;

    WaitForSeconds delay;
    private int timesShown;

    #endregion

    #region Properties

    public int Damage
    {
        get => config.damage;
    }

    public bool CanDammagePlayer
    {
        get => config.canDamagePlayer;
    }

    public bool CanDammageEnemy
    {
        get => config.canDammageEnemies;
    }

    #endregion

    #region Monobehaviour CallBacks

    private void Awake()
    {
        mTransform = transform;
        delay = new WaitForSeconds(config.lifeTime);
        if (!TryGetComponent(out mRigidBody))
        {
            mRigidBody = gameObject.AddComponent<Rigidbody2D>();
        }

        spriteRenderer.sprite = config.sprite;
    }

    private void OnEnable()
    {
        mRigidBody.velocity = mTransform.up * config.velocity;
        StartCoroutine(disableAfterLifeTime());
    }

    private void OnDisable()
    {
        mRigidBody.Sleep();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameObject.activeInHierarchy)
            return;
        if (collision.collider.transform.parent.TryGetComponent<IDamageable>(out var dammageAble))
        {
            bool shouldApply = false;
            if (collision.collider.transform.parent.tag != "Player")
            {
                if (CanDammageEnemy)
                {
                    shouldApply = true;
                }
            }
            else
            {
                if (CanDammagePlayer)
                    shouldApply = true;
            }

            if (shouldApply)
                dammageAble.OnGettingDamage(config.damage);
        }

        gameObject.SetActive(false);
    }

    #endregion

    #region Coroutins

    IEnumerator disableAfterLifeTime()
    {
        yield return delay;
        gameObject.SetActive(false);
    }

    #endregion
}