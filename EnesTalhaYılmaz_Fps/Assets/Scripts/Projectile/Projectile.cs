using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Projectile{
public class Projectile : MonoBehaviour
{
    Timer.WaitForTime waitForTime;
    [SerializeField] int destroySecProjectile=1;
    IDamageable damageable;
    [SerializeField] int damagePoint=10;
    private void Awake() {
        waitForTime=new Timer.WaitForTime();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForTime.WaitForSec(destroySecProjectile)){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Ontrigger enter");
        Debug.Log("other.CompareTag(Damageable)"+other.CompareTag("Damageable"));
        Debug.Log("other.tag"+other.tag);
     if(other.CompareTag("Player")){
         damageable= other.GetComponent<IDamageable>();
         damageable.Damage(damagePoint);
     }
    }
}
}

