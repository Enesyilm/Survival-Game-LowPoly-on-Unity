using System;
using Timer;
using UnityEngine;

public static class DayTimeState {
    static int previousHour=0;
    public static DayTimes currentDayTime;
    public static DayTimes DayTimeStates(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime,TimeSpan midNightTime)
{
    
    if (previousHour != currentTime.Hour)
    {
        
        if (currentTime.Hour == sunriseTime.Hours)
        {
            currentDayTime=DayTimes.Sunrise;
            
        }
        else if(currentTime.Hour == sunsetTime.Hours)
        {
            currentDayTime=DayTimes.Sunset;
        }
        else if(currentTime.Hour == midNightTime.Hours)
        {
            currentDayTime=DayTimes.Midnight;
        }
        else
        {
            currentDayTime=DayTimes.NullTime;
        }
        previousHour = currentTime.Hour;
        return currentDayTime;
    }
    else{
        currentDayTime=DayTimes.NullTime;
        return currentDayTime;
    }
    
}

}