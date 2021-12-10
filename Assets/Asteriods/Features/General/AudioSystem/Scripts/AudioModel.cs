using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audios;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioModel", menuName = "Asteriods/General/AudioModel")]
public class AudioModel : ScriptableObject
{
   public List<AudioClipPair> audioClips;
   public GameObject audioPlayerPrefab;
   public AudioMixer mixer;
   public string AudioChannelKey;
   public string MusicChannelKey;


}

namespace Audios
{
   [Serializable]
   public class AudioClipPair
   {
      public ClipName key;
      public AudioClip clip;
   }
   [Serializable]
   public enum ClipName
   {
      SHOOT,
      ASTROID_EXPLOSION,
      SHIP_EXPLOSION
   }
}