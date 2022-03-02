using System;
using UnityEngine;

namespace Timer
{
    public interface IRotateTheSun
    {
        void RotateSun(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime, Light sunLight,WeatherChanger weatherChanger);
    }
}
