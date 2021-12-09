using System;
using System.Collections;
using System.Collections.Generic;
using AstroidFeatures;
using Sirenix.OdinInspector;
using UnityEngine;

public class AstroidHealth :MonoBehaviour ,IDamageable
{

    #region  Fields

  [SerializeField]  private int initHealth;
  [SerializeField]    private AstroidSize size;
  [SerializeField]    private int health;
  [SerializeField]     private int offspringCount;
  private Sprite mSprite;

    #endregion

    #region Monobehaviour callbacks

    private void OnCollisionEnter(Collision other)
    {
       
    }

    #endregion

    #region Mehtods

    public void Initialize(AstroidSize Size,Sprite sprite)
    {
        var data = MainContainer.AstroidGenerator.GetAstroidData(Size);
        initHealth = data.hp;
        offspringCount = data.astroidCountToCreate;
        size = Size;
        health = initHealth;
        mSprite = sprite;
    }

    public void OnGettingDamage(int damage)
    {
        health -= damage;
        if(health<=0)
            OnDie();
        
    }
[Button]
    public void OnDie()
    {
     MainContainer.AstroidGenerator.CreateAstroids(transform.position,size,offspringCount,mSprite);
     MainContainer.AstroidGenerator.OnAstroidDie();
     //add some effects here maybe
     gameObject.SetActive(false);
    }

    #endregion
  
}
