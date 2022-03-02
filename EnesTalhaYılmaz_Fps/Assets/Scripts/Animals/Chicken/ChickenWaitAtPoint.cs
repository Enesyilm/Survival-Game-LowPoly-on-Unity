using UnityEngine;

public class ChickenWaitAtPoint : MonoBehaviour {
        
    [SerializeField] int WaitingSec;
    ChickenWaitAtPoint wait;
    Timer.WaitForTime waitForTime;

    private void Awake() {
        waitForTime=new Timer.WaitForTime();
    }
    public bool WaitAtPoint(bool isPatrolingFinished,Animator animator){
        if(waitForTime.WaitForSec(WaitingSec)){
            animator.SetBool("isRuning",true);
            return isPatrolingFinished=false;
        }
        else{animator.SetBool("isRuning",false);
            return isPatrolingFinished=true;
        }
    }
    
}