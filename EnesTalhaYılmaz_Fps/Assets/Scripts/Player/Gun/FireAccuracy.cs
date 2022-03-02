using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class FireAccuracy : MonoBehaviour
{
    [SerializeField] int shootingAccuracy=10;
   public bool HitChance(){
        int currentPossibility=Random.Range(0, 100);
        if(currentPossibility<shootingAccuracy){
            return true;

        }
        else{
            return false;
        }

    }
}
}

