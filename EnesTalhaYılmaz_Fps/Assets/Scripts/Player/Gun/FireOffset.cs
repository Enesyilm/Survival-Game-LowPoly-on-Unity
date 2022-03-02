using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class FireOffset : MonoBehaviour
{
    [SerializeField] float bulletPerMinute=10f;
    private float fireTimer=0;
    public float FireTimer   // property
    {
        get { return fireTimer; }
        set { fireTimer = value; }
    }
    AmmoIndicator ammoIndicator;
    void Awake(){
        ammoIndicator = GetComponent<AmmoIndicator>();
    }
   public bool IsShootable(){
         if(fireTimer<60f/bulletPerMinute)
        {
            ammoIndicator.changeAmmoTextColor(Color.red);
            fireTimer+=Time.deltaTime;
            return false;
        }
        else{
            ammoIndicator.changeAmmoTextColor(Color.green);
            return true;
        }
    }
}
}

