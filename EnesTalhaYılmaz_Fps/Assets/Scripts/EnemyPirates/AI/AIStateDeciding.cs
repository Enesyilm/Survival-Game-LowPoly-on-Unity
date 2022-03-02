using UnityEngine;
using UnityEngine.AI;

public class AIStateDeciding : MonoBehaviour {
    private IPirateChaseDynamic chaseDynamic;
    private IPiratePatrolDynamic patrolDynamic;
    private IPirateAttackDynamic attackDynamic;
    public bool IsEnemyDeath=false;
    bool IsWalkingAlreadyWorks=false;
    private void Awake() {
         chaseDynamic=GetComponent<IPirateChaseDynamic>();
        patrolDynamic=GetComponent<IPiratePatrolDynamic>();
        attackDynamic=GetComponent<IPirateAttackDynamic>();
    }
    public void AIStateDecider(Collider closestCollider,float closestColliderRange,NavMeshAgent agent,float attackRange,Animator animator)
    {

        // var mask = ~(LayerMask.GetMask("Player") | LayerMask.GetMask("Wall"));
        if(!IsEnemyDeath){
            if(closestCollider != null)
            {
                DecideAttackOrChase(closestCollider, closestColliderRange, agent, attackRange, animator);
            }
            else
            {
                patrolDynamic.Patroling(agent);
            }
        }
    }

    private void DecideAttackOrChase(Collider closestCollider, float closestColliderRange, NavMeshAgent agent, float attackRange, Animator animator)
    {
        if (closestColliderRange > attackRange)
        {
            if (!IsWalkingAlreadyWorks)
            {
                //animator.SetBool("IsWalking",true);
                Debug.Log("animator.SetBool(,true);");
                IsWalkingAlreadyWorks = true;
            }

            chaseDynamic.ChasePlayer(agent, closestCollider.transform);
        }
        else
        {
            IsWalkingAlreadyWorks = false;
            animator.SetBool("IsWalking", false);
            attackDynamic.AttackPlayer(agent, closestCollider.transform, animator);
        }
    }
}