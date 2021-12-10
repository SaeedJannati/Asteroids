using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Audios;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   [SerializeField] private AudioModel config;
   private const float minVoloume = -80.0f;
   private const float maxVoloume = 0.0f;
   
   public static event Action OnAudioEnableChanged;
   public static event Action OnMusicEnableChanged;
   public void RequestAudio(ClipName audioKey)
   {
      var clip = config.audioClips.FirstOrDefault(item => item.key == audioKey).clip;
      if (ObjectPool.Instantiate(config.audioPlayerPrefab, transform)
         .TryGetComponent(out AudioPlayer player))
      {
         player.Initialize(clip);
      }

   }

   private void Start()
   {
      SetAudioVolume();
      SetMusicVolume();
   }

   void SetAudioVolume()
   {
     var enable= AudioManagerPrefs.AduioEnable ;
      float amount = enable ? maxVoloume : minVoloume;
      config.mixer.SetFloat(config.AudioChannelKey, amount);
   }

   void SetMusicVolume()
   {
      var enable= AudioManagerPrefs.MusicEnable ;
      float amount = enable ? maxVoloume : minVoloume;
      config.mixer.SetFloat(config.MusicChannelKey, amount);
   }

   public bool GetAudioEnable()
   {
      return AudioManagerPrefs.AduioEnable;
   }
   public void ChangeAudioEnable()
   {
      var enable= AudioManagerPrefs.AduioEnable;
      enable = !enable;
      AudioManagerPrefs.AduioEnable = enable;
      float amount = enable ? maxVoloume : minVoloume;
      config.mixer.SetFloat(config.AudioChannelKey, amount);
      OnAudioEnableChanged?.Invoke();
   }

   public bool GetMusicEnable()
   {
      return AudioManagerPrefs.MusicEnable;
   }

   public void ChangeMusicEnable()
   {
      var enable= AudioManagerPrefs.MusicEnable;
      enable = !enable;
      AudioManagerPrefs.MusicEnable = enable;
      float amount = enable ? maxVoloume : minVoloume;
      config.mixer.SetFloat(config.MusicChannelKey, amount);
      OnMusicEnableChanged?.Invoke();
   }
}
