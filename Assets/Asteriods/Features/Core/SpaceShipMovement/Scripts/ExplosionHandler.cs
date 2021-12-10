using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
   WaitForSeconds delay=new WaitForSeconds(2.0f);
   void OnEnable()
   {
      StartCoroutine(DisableWithDelay());

   }

   IEnumerator DisableWithDelay()
   {
      yield return delay;
      gameObject.SetActive(false);
   }
}
