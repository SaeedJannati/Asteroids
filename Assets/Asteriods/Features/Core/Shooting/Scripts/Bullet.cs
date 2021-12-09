using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Fields

        [SerializeField] Transform mTransform;
        [SerializeField] Rigidbody2D mRigidBody;
       
     
        [SerializeField] private BulletModel config;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        WaitForSeconds delay;
        private int timesShown;
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
        print($"Collision:{collision.gameObject.name}");
        if (!gameObject.activeInHierarchy)
            return;
        if (collision.collider.transform.parent.TryGetComponent<IDamageable>(out var dammageAble))
        {
            bool shouldApply = false;
            if (collision.collider.transform.parent.tag != "Player")
            {
                if (config.canDammageEnemies)
                {

                    shouldApply = true;

                }
            }
            else
            {
                shouldApply = true;


            }
            if (shouldApply)
                dammageAble.OnGettingDamage(config.damage);
        }
        gameObject.SetActive(false);
    }
    #endregion

    #region  Methods

    

    #endregion

    #region Coroutins

    
    IEnumerator disableAfterLifeTime()
    {
        yield return delay;
        gameObject.SetActive(false);
    }
    #endregion
}
