using UnityEngine;
using UnityEngine.AI;

public interface IPirateChaseDynamic
{
    void ChasePlayer(NavMeshAgent agent, Transform player);
}
