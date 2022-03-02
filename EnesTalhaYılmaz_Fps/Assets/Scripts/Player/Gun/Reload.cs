using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class Reload : MonoBehaviour
{
    [SerializeField] float reloadTime=10f;
    [SerializeField] AudioSource audioSource;
    private bool isReloading = false;
    public bool IsReloading{
        get{return isReloading;}
        set{isReloading=value;}
    }
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    void OnEnable(){
        isReloading=false;
    }
   public IEnumerator Reloadweapon(EnesTalhaYılmaz_Fps.Gun.MagStatus magStatus){
            isReloading=true;
            yield return new WaitForSeconds(reloadTime);
            magStatus.CurrentAmmo=magStatus.MagazineCap;
            SoundManager.Instance.PlaySound(SoundType.PlayerReload,audioSource);
            isReloading=false;
    }
}
}

