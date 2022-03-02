using UnityEngine;
using UnityEngine.AI;

public class PirateAttackDynamic : MonoBehaviour, IPirateAttackDynamic
{
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] GameObject projectile;

    public void AttackPlayer(NavMeshAgent agent, Transform player,Animator animator)
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            animator.SetTrigger("Attack");
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position+new Vector3(0,1f,0), Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 6f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}