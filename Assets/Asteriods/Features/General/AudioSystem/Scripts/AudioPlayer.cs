using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  [SerializeField] private AudioSource audioSource;
  
  public void Initialize(AudioClip clip)
  {
    audioSource.clip = clip;
    audioSource.Play();
    StartCoroutine(DisableAfterPlay(clip.length));
  }

  IEnumerator DisableAfterPlay(float clipLength)
  {
    yield return  new WaitForSeconds(clipLength);
    gameObject.SetActive(false);
  }
}
