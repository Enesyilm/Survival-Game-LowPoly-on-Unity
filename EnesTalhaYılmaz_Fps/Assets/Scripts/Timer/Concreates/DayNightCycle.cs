using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Timer{
    
public enum NightType{
    NormalNight,
    BloodyMoon
}
public class DayNightCycle : MonoBehaviour
{
    
    [Header("DayTime Settings")]
    [SerializeField]private float timeMultiplier;
    [SerializeField]private float startHour;
    [SerializeField]private float sunsetHour;
    [SerializeField]private float sunriseHour;
    private float midNightHour=0;
    public DateTime currentTime;
    [Header("Light Settings")]
    [SerializeField] AnimationCurve lightChangeCurve;
    [SerializeField]  Light sunLight;
    [SerializeField] NightType currentNightType=NightType.NormalNight;
    [SerializeField]WeatherChanger weatherChanger;
    public TimeSpan sunriseTime;
    public TimeSpan sunsetTime;
    public TimeSpan midNightTime;
    RotateTheSun rotateTheSun;
    IUpdatingHDRISettings IupdatingHDRISettings;
    IUpdatinglightSettings IupdatinglightSettings;
    DayTimes dayTime;
    BloodyMoon bloodyMoon;
    private void Awake() { 
        rotateTheSun=GetComponent<RotateTheSun>();        
        bloodyMoon=GetComponent<BloodyMoon>();        
        IupdatingHDRISettings=GetComponent<IUpdatingHDRISettings>();        
        IupdatinglightSettings=GetComponent<IUpdatinglightSettings>();   
    }
    void Start()
    {
        currentTime=DateTime.Now.Date+TimeSpan.FromHours(startHour);
       
        sunriseTime=TimeSpan.FromHours(sunriseHour);
        midNightTime=TimeSpan.FromHours(midNightHour);
        sunsetTime=TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        DayCounter.CountElapsedDays();
        dayTime =DayTimeState.DayTimeStates(currentTime, sunriseTime, sunsetTime,midNightTime);
        currentNightType=bloodyMoon.BloodyMoonCounter(currentTime,sunriseTime,sunsetTime,dayTime);
        UpdateTimeOfDay();
        rotateTheSun.RotateSun(currentTime,sunriseTime,sunsetTime,sunLight,weatherChanger);
        IupdatinglightSettings.UpdatelightSettings(sunLight,lightChangeCurve,currentNightType);
        IupdatingHDRISettings.UpdateHDRISettings(currentTime,sunriseTime,sunsetTime,sunLight,lightChangeCurve,currentNightType,weatherChanger);
        
    }
    public void UpdateTimeOfDay(){
        
        currentTime=currentTime.AddSeconds(Time.deltaTime*timeMultiplier);
       
    }
    
   
}
}

