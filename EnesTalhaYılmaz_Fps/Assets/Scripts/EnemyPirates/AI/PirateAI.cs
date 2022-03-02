using UnityEngine;
using System;
using UnityEngine.AI;

public class PirateAI : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] LayerMask[] whatIsDestructable;
    [SerializeField] float sightRange,attackRange;
    [SerializeField] bool playerInSightRange, playerInAttackRange;
    [SerializeField] Animator animator;
    private AIStateDeciding aIStateDecider;
    FindClosestEnemys findClosestEnemy;
    
    float currentRange;

    public float SightRange { get => sightRange; set => sightRange = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }

    private void Awake()
    {
        
        animator=GetComponentInChildren<Animator>();
        findClosestEnemy=GetComponent<FindClosestEnemys>();
        aIStateDecider=GetComponent<AIStateDeciding>();
        agent = GetComponent<NavMeshAgent>();

        
    }

    private void Update()
    {
        var tuple=findClosestEnemy.FindClosestEnemy(currentRange,sightRange);
        float closestColliderRange=tuple.Item2;
        Collider closestCollider= tuple.Item1;
        aIStateDecider.AIStateDecider(closestCollider,closestColliderRange,agent,attackRange,animator);
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
       
    }

    

   
    // public void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attackRange);
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, sightRange);
    // }
}
