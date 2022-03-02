using System;
using System.Collections.Generic;
using UnityEngine;

namespace Timer{
    public enum DayTimes{
        Sunset,
        Sunrise,
        Midnight,
        NullTime,
    }
public class BloodyMoon : MonoBehaviour
{
    // Timer.DayNightCycle dayNightCycle;
    [SerializeField]int daysPerBloodyMoon;
    
    
    AudioSource audioSource;
    DecideItsBloodyOrNot decideItsBloodyOrNot;
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
        decideItsBloodyOrNot=GetComponent<DecideItsBloodyOrNot>();
    }
   public NightType BloodyMoonCounter(DateTime currentTime,TimeSpan sunriseTime,TimeSpan sunsetTime,DayTimes dayTime)
        {
            

            return decideItsBloodyOrNot.DecidingDayBloodyOrNot(daysPerBloodyMoon,dayTime,audioSource);
        }

        
    }

}
