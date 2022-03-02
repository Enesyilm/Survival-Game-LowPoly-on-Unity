
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType{
    PlayerDeath,
    EnemyDeath,
    PlayerHit,
    EnemyHit,
    PlayerChopTree,
    PlayerGunShoot,
    PlayerReload,
    SwitchWeapon,
    CampFireSound,
    WallHit,
    WallDestroy,
    BloodymoonMorning,
    BloodymoonEvening,
    NormalEvening,
    NormalMorning,
    TreeFall,
    ChickenGotHit,
    ChickenCasual,
    RainLoop,
    StormLoop,
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [Header("Entities")]
    [SerializeField] AudioClip ChickenGotHit;
    [SerializeField] AudioClip[] ChickenCasual;
    [Header("Relative with Player")]
    [SerializeField] AudioClip PlayerDeath;
    [SerializeField] AudioClip PlayerHit;
    [SerializeField] AudioClip PlayerChopTree;
    [SerializeField] AudioClip PlayerGunShoot;
    [SerializeField] AudioClip PlayerReload;
    [SerializeField] AudioClip SwitchWeapon;
    [Header("Events")]
    [SerializeField] AudioClip TreeFall;
    [SerializeField] AudioClip CampFireSound;
    
    [Header("Relative with Enemy")]
    [SerializeField] AudioClip EnemyDeath;
    [SerializeField] AudioClip EnemyHit;
    [SerializeField] AudioClip WallHit;
    [SerializeField] AudioClip WallDestroy;
    [Header("Days")]
    [SerializeField] AudioClip BloodymoonMorning;
    [SerializeField] AudioClip BloodymoonEvening;
    [SerializeField] AudioClip NormalMorning;
    [SerializeField] AudioClip NormalEvening;

    [Header("Weather")]
    [SerializeField] AudioClip RainLoop;
    [SerializeField] AudioClip StormLoop;
    [SerializeField] AudioSource effectSound;
    private void Awake() {
        if(Instance !=null){
            Destroy(gameObject);
        }
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlaySound(SoundType soundType,AudioSource audioSource){
        switch(soundType){
            case SoundType.PlayerDeath:
                audioSource.PlayOneShot(PlayerDeath);
                break;
            
            case SoundType.EnemyDeath:
                audioSource.PlayOneShot(EnemyDeath);
                break;
            
            case SoundType.PlayerHit:
                audioSource.PlayOneShot(PlayerHit);

                break;
            
            case SoundType.EnemyHit:
                audioSource.PlayOneShot(EnemyHit);

                break;
            
            case SoundType.PlayerChopTree:
                audioSource.PlayOneShot(PlayerChopTree);

                break;
            case SoundType.BloodymoonMorning:
                audioSource.PlayOneShot(BloodymoonMorning);

                break;
            case SoundType.BloodymoonEvening:
                audioSource.PlayOneShot(BloodymoonEvening);

                break;
            case SoundType.NormalMorning:
                audioSource.PlayOneShot(NormalMorning);

                break;
            case SoundType.NormalEvening:
                audioSource.PlayOneShot(NormalEvening);

                break;
            
            case SoundType.PlayerGunShoot:
                audioSource.PlayOneShot(PlayerGunShoot);

                break;
            case SoundType.SwitchWeapon:
                audioSource.PlayOneShot(SwitchWeapon);

                break;
            
            case SoundType.PlayerReload:
                audioSource.PlayOneShot(PlayerReload);

                break;
            case SoundType.WallHit:
                audioSource.PlayOneShot(WallHit);

                break;
            case SoundType.WallDestroy:
                audioSource.PlayOneShot(WallDestroy);

                break;
            case SoundType.TreeFall:
                audioSource.PlayOneShot(TreeFall);

                break;
            case SoundType.ChickenCasual:
                audioSource.PlayOneShot(ChickenCasual[Random.Range(0,ChickenCasual.Length)]);

                break;
            case SoundType.ChickenGotHit:
                audioSource.PlayOneShot(ChickenGotHit);

                break;
            case SoundType.CampFireSound:
                audioSource.PlayOneShot(CampFireSound);

                break;
            case SoundType.RainLoop:
                audioSource.PlayOneShot(RainLoop);

                break;
            case SoundType.StormLoop:
                audioSource.PlayOneShot(StormLoop);

                break;
            
        }
    }
}
