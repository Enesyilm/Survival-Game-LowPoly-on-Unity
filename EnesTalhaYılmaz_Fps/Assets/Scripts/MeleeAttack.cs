using System;
using System.Collections;
using System.Collections.Generic;
using EnesTalhaYılmaz_Fps.Projectile;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]float radius;
    [SerializeField]string tagCanAttack;
    Controllers.PcControllers input;
    [SerializeField]int damageAmount;
    [Header("Sphere Offset")]
    IDamageable damageable;
    // Start is called before the first frame update
    [SerializeField]Vector3 offsetValue;
    
    private void Awake() {
        input=new Controllers.PcControllers();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckInput()){
            Attack();
        }
    }

    private bool CheckInput()
    {
        if(input.semiFireInput){
            PlayerStateBools.IsAttacking=true;
            return true;
        }
        else{
            return false;
        }
        
    }

    private void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + offsetValue, radius);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == tagCanAttack)//this section have to be can change on inspector by this way i can specify the target
            {
                
                damageable = hitCollider.GetComponent<IDamageable>();
                Debug.Log("Attack() calıştı"+damageable);
                damageable.Damage(damageAmount);
            }
        }
    }

    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position+offsetValue,radius);
    }

}
