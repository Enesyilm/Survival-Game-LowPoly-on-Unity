using System;
using UnityEngine;

namespace Timer
{

    public class RotateTheSun : MonoBehaviour, IRotateTheSun
    {
        
        CalculationOfTimeDifferenceInDay calculationOfTimeDifferenceInDay;
        LerpIncreasing lerpIncreaser;
        float sunlightRotation;
        private void Awake()
        {
            calculationOfTimeDifferenceInDay = new CalculationOfTimeDifferenceInDay();
            lerpIncreaser=new LerpIncreasing();
        }
        public void RotateSun(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime, Light sunLight,WeatherChanger weatherChanger)
        {
            bool isDayTime= currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime;
            if (isDayTime)
            {
                RotateSunAccordingToWeather(currentTime, sunriseTime, sunsetTime, weatherChanger);

            }
            else
            {

                double percentage = FindPercentageOfRotation(currentTime, sunsetTime, sunriseTime);
                sunlightRotation = Mathf.Lerp(180, 360, (float)percentage);
            }
            sunLight.transform.rotation = Quaternion.AngleAxis(sunlightRotation, Vector3.right);

        }

        private void RotateSunAccordingToWeather(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime, WeatherChanger weatherChanger)
        {
            if (weatherChanger.IsWeatherCaseActive)
            {
                //sunlightRotation = 180;
                double percentage = FindPercentageOfRotation(currentTime, sunriseTime, sunsetTime);
                // sunlightRotation = Mathf.Lerp(0, 180, (float)percentage*2);
                sunlightRotation=lerpIncreaser.LerpIncreaser(180,sunlightRotation);
                
                
            }
            else
            {
                lerpIncreaser.timeElapsed=0;
                double percentage = FindPercentageOfRotation(currentTime, sunriseTime, sunsetTime);
                sunlightRotation = Mathf.Lerp(0, 180, (float)percentage);
            }
        }

        private double FindPercentageOfRotation(DateTime currentTime, TimeSpan fromTime, TimeSpan ToTime)
        {
            TimeSpan sunriseToSunsetDuration = calculationOfTimeDifferenceInDay.CalculateTimeDifference(fromTime, ToTime);
            TimeSpan timeSinceSunrise = calculationOfTimeDifferenceInDay.CalculateTimeDifference(fromTime, currentTime.TimeOfDay);
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            return percentage;
        }
    }
}
