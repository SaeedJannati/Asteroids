using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstroidFeatures;
[CreateAssetMenu(fileName = "AstroidGeneretorModel", menuName = "Asteriods/Astroid/Generator" )]
public class AstroidGeneratorModel : ScriptableObject
{
    #region Fields
    public AstroidGeneratorSpriteContainer spriteContainer;
   public List<AstroidData> astroidsData;
   public GameObject astoirdExplosion;
    public float minSpeed;
    public float maxSpeed;

    public int rotatingChance;

    public float minRotSpeed;
    public float maxRotSpeed;
    public int initAstroidCount;
    public int increasePeriodInSeconds;
    public int increaseRate;

    public float minDelayPeriod;
    public float maxdelayPeriod;

    #endregion


}

namespace AstroidFeatures
{
    [Serializable]
    public class AstroidData
    {
        public AstroidSize size;
        public int hp;
        public int astroidCountToCreate;
        public GameObject astroidPrefab;
        public float explosionScale;
        public int damage;
        public int score;

    }

    [Serializable]
    public enum AstroidSize
    {
        SMALL=0,
        MID,
        LARGE,
        END
    }
}
