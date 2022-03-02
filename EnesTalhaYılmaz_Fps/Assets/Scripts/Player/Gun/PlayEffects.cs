using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class PlayEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactEffect;
   public void PlayMuzzleFlashEffect(){
            muzzleFlash.Play();
        }
    public void PlayImpactEffect(RaycastHit hit){
        GameObject ImpactGo=Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(ImpactGo,1f);
    }
}
}

