using System;
using UnityEngine;

public class FindClosestEnemys : MonoBehaviour {
     public Tuple<Collider,float> FindClosestEnemy(float currentRange,float sightRange)
    {
        Collider[] hitCollider;
        Collider closestCollider=null;
        var layerMask = LayerMask.GetMask("Player", "Wall");
        hitCollider = Physics.OverlapSphere(transform.position, sightRange, layerMask);

        float min = 0;
        foreach (Collider hit in hitCollider)
        {


            currentRange = Vector3.Distance(transform.position, hit.gameObject.transform.position);
            if (min == 0)
            {
                min = currentRange;
                closestCollider = hit;
            }
            if (currentRange < min)
            {
                min = currentRange;
                closestCollider = hit;
                
            }
        }

        return new Tuple<Collider,float>(closestCollider, min);
    }
}