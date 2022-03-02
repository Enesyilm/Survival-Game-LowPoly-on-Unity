using UnityEngine;
using UnityEngine.AI;

public interface IPirateAttackDynamic
{
    void AttackPlayer(NavMeshAgent agent, Transform player,Animator animator);
}
