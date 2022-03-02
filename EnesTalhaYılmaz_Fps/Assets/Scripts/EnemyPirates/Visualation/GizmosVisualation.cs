using UnityEngine;

public class GizmosVisualation : MonoBehaviour {
    PirateAI pirateAI;
    private void Awake() {
        pirateAI=GetComponent<PirateAI>();
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pirateAI.AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pirateAI.SightRange);
    }

}