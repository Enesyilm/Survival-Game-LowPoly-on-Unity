using System;
using Timer;
using UnityEngine;

public interface IUpdatingHDRISettings
{
    void UpdateHDRISettings(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime, Light sunLight, AnimationCurve lightChangeCurve,NightType currentNightType,WeatherChanger weatherChanger);
}
