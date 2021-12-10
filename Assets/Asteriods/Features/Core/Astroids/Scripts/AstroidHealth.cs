using System;
using System.Collections;
using System.Collections.Generic;
using AstroidFeatures;
using Sirenix.OdinInspector;
using UnityEngine;

public class AstroidHealth :MonoBehaviour ,IDamageable,IDammager
{

    #region  Fields

  [SerializeField]  private int initHealth;
  [SerializeField]    private AstroidSize size;
  [SerializeField]    private int health;
  [SerializeField]     private int offspringCount;
  [SerializeField] private int damage;
  private Sprite mSprite;

    #endregion

    #region Properties

     public int Damage { get=>damage; }
     public bool CanDammagePlayer { get=>true; }
     public bool CanDammageEnemy { get=>false; }

     #endregion
    #region Monobehaviour callbacks

 
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
        damage = data.damage;
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
