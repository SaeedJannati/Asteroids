using System;
using System.Collections;
using System.Collections.Generic;
using AstroidFeatures;
using Audios;
using Sirenix.OdinInspector;
using UnityEngine;

public class AstroidHealth : MonoBehaviour, IDamageable, IDammager
{
    #region Fields

    private int initHealth;
    private AstroidSize size;
    private int health;
    private int offspringCount;
    private int damage;
    private int score;
    private Sprite mSprite;

    #endregion

    #region Properties

    public int Damage
    {
        get => damage;
    }

    public bool CanDammagePlayer
    {
        get => true;
    }

    public bool CanDammageEnemy
    {
        get => false;
    }

    private float explosionScale;

    #endregion

    #region Monobehaviour callbacks

    private void Awake()
    {
        AstroidGenerator.OnClearTheScreen += DisableAstroid;
    }

    private void OnDestroy()
    {
        AstroidGenerator.OnClearTheScreen -= DisableAstroid;
    }

    #endregion

    #region Mehtods

    void DisableAstroid()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(AstroidSize Size, Sprite sprite)
    {
        var data = MainContainer.AstroidGenerator.GetAstroidData(Size);
        initHealth = data.hp;
        offspringCount = data.astroidCountToCreate;
        size = Size;
        health = initHealth;
        mSprite = sprite;
        damage = data.damage;
        explosionScale = data.explosionScale;
        score = data.score;
    }

    public void OnGettingDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            OnDie();
    }

    [Button]
    public void OnDie()
    {
        MainContainer.CameraShakeLogic.Shake();
        MainContainer.AstroidGenerator.CreateAstroids(transform.position, size, offspringCount, mSprite);
        MainContainer.AstroidGenerator.OnAstroidDie();
        ObjectPool.Instantiate(MainContainer.AstroidGenerator.ExplosionPrefab, transform.position, Quaternion.identity)
                .transform.localScale =
            Vector3.one * explosionScale;
        MainContainer.ScoreLogic.AddScore(score);
        gameObject.SetActive(false);
        MainContainer.AudioManager.RequestAudio(ClipName.ASTROID_EXPLOSION);
    }

    #endregion
}