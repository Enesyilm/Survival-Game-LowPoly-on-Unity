using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class Shoot : MonoBehaviour
{
    PlayEffects playEffects;
    DidItHitsToTarget didItHitsToTarget;
    [SerializeField] Camera FpsCamera;
    AudioSource audioSource;
     
    
    float range=1000f;

    void Awake(){
        playEffects=GetComponent<PlayEffects>();
        audioSource=GetComponent<AudioSource>();
        FpsCamera=Camera.main;
        didItHitsToTarget=GetComponent<DidItHitsToTarget>();
    }
   public void ShootBullet(){
        PlayerStateBools.IsShooting=true;
        Debug.Log("PlayerStateBools.IsShooting=true");
        playEffects.PlayMuzzleFlashEffect();
        SoundManager.Instance.PlaySound(SoundType.PlayerGunShoot,audioSource);
        RaycastHit hit;
        if(Physics.Raycast(FpsCamera.transform.position,FpsCamera.transform.forward,out hit,range)){           
           didItHitsToTarget.GiveDamageToTarget(hit);
            playEffects.PlayImpactEffect(hit);
        }
        
    }
}
}

