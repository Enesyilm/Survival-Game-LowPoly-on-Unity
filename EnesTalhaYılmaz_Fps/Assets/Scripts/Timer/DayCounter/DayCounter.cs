using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DayCounter
{
    public static int elapsedDays=0;
    // Start is called before the first frame update
    
    public static void CountElapsedDays()
    {
        if (DayTimeState.currentDayTime == Timer.DayTimes.Midnight)
        {
            elapsedDays++;
        }
    }
}
