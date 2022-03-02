using System.Collections;
using System.Collections.Generic;
using EnesTalhaYılmaz_Fps.Projectile;
using UnityEngine;

public class ChickenHealth : MonoBehaviour,IDamageable
{
    [SerializeField] AudioSource audioSource;
    [SerializeField]int health=50;
    public void Damage(int damagePoint){
        health-=damagePoint;
        SoundManager.Instance.PlaySound(SoundType.PlayerHit,audioSource);
        if(health<=0){
            Destroy(gameObject);
        }
    
    }
}
