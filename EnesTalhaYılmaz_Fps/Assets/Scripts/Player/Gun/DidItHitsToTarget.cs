using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class DidItHitsToTarget : MonoBehaviour
{
    [SerializeField] int damage=40;
    FireAccuracy fireAccuracy;
    void Awake(){
        fireAccuracy=GetComponent<FireAccuracy>();
    }
    public void GiveDamageToTarget(RaycastHit hit){
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
         if(target!=null && fireAccuracy.HitChance()==true ){
                target.Damage(damage);
            }
    }
    
}
}

