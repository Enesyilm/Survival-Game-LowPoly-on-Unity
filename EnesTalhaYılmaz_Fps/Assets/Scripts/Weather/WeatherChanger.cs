using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentWeatherType{
    Rain,
    Storm,
    NormalWeather,

}
public class WeatherChanger : MonoBehaviour
{
    [SerializeField]int minMinuteBetweenWeatherCase=1;
    [SerializeField] int maxMinuteBetweenWeatherCase=2;
    [Range(1,10)][SerializeField]int normalWeatherChance10PointScale=6;
    [SerializeField]WeatherCases[] WeatherCases;
    Timer.WaitForTime waitForTime;
    [SerializeField]Timer.DayNightCycle dayNightCycle;
     
    GameObject CurrentWeatherObject;
    public CurrentWeatherType currentWeatherType=CurrentWeatherType.NormalWeather;
    public bool IsWeatherCaseActive=false;
    private void Awake()
    {
        NormalDayWithoutWeatherCase();
        waitForTime = new Timer.WaitForTime();
        
    }

    void Update()
    {   
         RandomlyChangeWeather();
        if (IsWeatherCaseActive)
        {

        }
    }
    

    private void RandomlyChangeWeather()
    {
        bool weatherOffset=waitForTime.WaitForMinute(Random.Range(minMinuteBetweenWeatherCase, maxMinuteBetweenWeatherCase + 1));
        if (weatherOffset){
            bool WeatherCaseChance=Random.Range(1, 11) >= normalWeatherChance10PointScale;

            if (WeatherCaseChance&&!IsWeatherCaseActive)
            {
                WeatherCases randomlySelectedWeatherCase=WeatherCases[Random.Range(0, WeatherCases.Length)];
                CurrentWeatherObject=Instantiate(randomlySelectedWeatherCase.weatherObject,randomlySelectedWeatherCase.SpawnPoint,Quaternion.Euler(randomlySelectedWeatherCase.SpawnPointRotation),transform); 
                currentWeatherType=randomlySelectedWeatherCase.WeatherType;
                IsWeatherCaseActive = true;//-25 204 32
            }
            else if(!(dayNightCycle.currentTime.TimeOfDay > dayNightCycle.sunriseTime && dayNightCycle.currentTime.TimeOfDay < dayNightCycle.sunsetTime))
            {
                IsWeatherCaseActive = false;
                NormalDayWithoutWeatherCase();

            }
        }
    }

    private void NormalDayWithoutWeatherCase()
    {
        foreach (WeatherCases weatherCase in WeatherCases)
        {
            currentWeatherType=CurrentWeatherType.NormalWeather;
            Destroy(CurrentWeatherObject);
        }
    }
}
