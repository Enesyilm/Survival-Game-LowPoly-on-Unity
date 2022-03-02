using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    NavMeshAgent agent;
    ChickenPatroling chickenPatroling;
    ChickenWaitAtPoint chickenWaitAtPoint;
    [SerializeField]Animator animator;
    [SerializeField]AudioSource audioSource;
    bool SoundAlreadyPlayed=false;

    bool isPatrolingFinished=true;
    
    private void Awake() {
        agent=GetComponent<NavMeshAgent>();
        chickenPatroling=GetComponent<ChickenPatroling>();
        chickenWaitAtPoint=GetComponent<ChickenWaitAtPoint>();
        
    }
    private void Update() {        
        if(isPatrolingFinished){
            isPatrolingFinished=chickenWaitAtPoint.WaitAtPoint(isPatrolingFinished,animator);
            SoundAlreadyPlayed=false;
        }
        else{
            if(!SoundAlreadyPlayed){

            SoundManager.Instance.PlaySound(SoundType.ChickenCasual,audioSource);
            }
            SoundAlreadyPlayed=true;
            isPatrolingFinished=chickenPatroling.Patroling(agent);
        }
    }
    
    
}