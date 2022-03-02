using UnityEngine;
using UnityEngine.AI;

public class PirateChaseDynamic : MonoBehaviour, IPirateChaseDynamic
{
    public void ChasePlayer(NavMeshAgent agent, Transform player)
    {
        agent.SetDestination(player.position);
    }
}