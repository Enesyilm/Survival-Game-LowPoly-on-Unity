using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timer{

public class WaitForTime
{
    float countTimer=0;
   public bool WaitForSec(int second)
    {
        if(countTimer>second){
            countTimer=0;
            return true;
        }
        else{
            countTimer+=Time.deltaTime;
            return false;
        }
                     
    }
    public bool WaitForMinute(int minute)
    {
        if(countTimer/60>minute){
            countTimer=0;
            return true;
        }
        else{
            countTimer+=Time.deltaTime;

            return false;
        }
                     
    }

}

}
