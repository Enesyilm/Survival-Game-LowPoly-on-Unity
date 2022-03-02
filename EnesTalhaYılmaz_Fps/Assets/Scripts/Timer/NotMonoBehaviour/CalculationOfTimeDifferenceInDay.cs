using System;
using UnityEngine;
namespace Timer{
public class CalculationOfTimeDifferenceInDay {
     public TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
        if (difference. TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours (24);
        }
        return difference;
    }
}
    
}
