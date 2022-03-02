using UnityEngine;

public class CheckOffsetTime {
        Timer.WaitForTime waitForTime;
        public bool canInteract=true;
        public CheckOffsetTime() {
            waitForTime=new Timer.WaitForTime();
            
        }
        public bool CheckInteractionOffsetTimes(int EventOffset)
    {
        if (waitForTime.WaitForSec(EventOffset))
        {
            canInteract = true;
           
        }
        if (canInteract)
        {
            return true;

        }
        return false;
    }

}