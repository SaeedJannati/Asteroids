using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "AstroidSpriteContainer", menuName = "Asteriods/Astroid/SpriteContainer" )]
public class AstroidGeneratorSpriteContainer : ScriptableObject
{
 #region  Fields

 [SerializeField] List<Sprite> AstroidSprites;

 #endregion

 #region  Methods


 public Sprite GetRandomSprite()
 {
  var randIndex = Random.Range(0, AstroidSprites.Count);
  return AstroidSprites[randIndex];
 }

 #endregion

}
