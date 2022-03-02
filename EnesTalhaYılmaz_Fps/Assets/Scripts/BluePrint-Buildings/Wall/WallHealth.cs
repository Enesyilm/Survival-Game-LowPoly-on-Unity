using System.Collections;
using System.Collections.Generic;
using EnesTalhaYılmaz_Fps.Projectile;
using UnityEngine;

public class WallHealth : MonoBehaviour,IDamageable
{
    [SerializeField] int health=100;
    AudioSource audioSource;
    bool alreadyPlayed=false;
    // Start is called before the first frame update
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Damage(int damagePoint){
        health-=damagePoint;
        SoundManager.Instance.PlaySound(SoundType.WallHit,audioSource);
        if(health<=0&& !alreadyPlayed){
            alreadyPlayed=true;
            SoundManager.Instance.PlaySound(SoundType.WallDestroy,audioSource);
            Destroy(gameObject,1.5f);
        }
    
    }
}
