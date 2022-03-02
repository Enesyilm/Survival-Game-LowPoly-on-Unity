using System;
using UnityEngine;
using Timer;

public class UpdatingHDRISettings : MonoBehaviour ,IUpdatingHDRISettings
{
    [Header("NormalDay Settings")]
    [Range(0.1f, 0.5f)] [SerializeField] float minExposureNormalDay;
    [Range(0.51f, 1f)] [SerializeField] float maxExposureNormalDay;
    [SerializeField]Material dayHdri;
    [SerializeField]Material nightHdri;
     [Header("Rain Settings")]
    [SerializeField]float minExposureRain;
    [Header("Storm Settings")]
    [SerializeField]float minExposureStorm;
    [Header("BloodyNight Settings")]
    [SerializeField] Color bloodyNightAmbientlight;
    [Range(0.1f, 0.5f)][SerializeField] float minExposureBloodyDay;
    LerpIncreasing lerpIncreaser;
    
    private void Awake() {
        lerpIncreaser=new LerpIncreasing();
    }
    public float currentExposure = 1f;
    public void UpdateHDRISettings(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime, Light sunLight, AnimationCurve lightChangeCurve,NightType currentNightType,WeatherChanger weatherChanger)
    {
        SetHdriAccordingToWeather(sunLight,weatherChanger,lightChangeCurve,currentNightType);
        ChangeHDRI(currentTime, sunriseTime, sunsetTime, currentNightType);
    }

    private void SetHDRIColor(NightType currentNightType)
    {
        if (currentNightType == NightType.BloodyMoon)
        {
            RenderSettings.skybox.SetColor("_Tint", bloodyNightAmbientlight);
        }
        else
        {
            RenderSettings.skybox.SetColor("_Tint", Color.grey);
        }
    }

    private void SetHdriAccordingToWeather(Light sunLight,WeatherChanger weatherChanger,AnimationCurve lightChangeCurve,NightType currentNightType)
    {       
        switch(weatherChanger.currentWeatherType){
            case CurrentWeatherType.Storm:
                currentExposure =lerpIncreaser.LerpIncreaser(minExposureStorm,currentExposure);
                RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
                break;
            case CurrentWeatherType.Rain:
                
                // currentExposure =lerpIncreaser.LerpIncreaser(minExposureRain,currentExposure);
                // RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
                break;
            case CurrentWeatherType.NormalWeather:
                lerpIncreaser.timeElapsed=0;
                float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
                if (currentNightType == NightType.BloodyMoon)
                {
                    currentExposure = Mathf.Lerp(minExposureBloodyDay, maxExposureNormalDay, lightChangeCurve.Evaluate(dotProduct));
                }
                else{
                    currentExposure = Mathf.Lerp(minExposureNormalDay, maxExposureNormalDay, lightChangeCurve.Evaluate(dotProduct));
                }
                
                
                RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
                break;
            }
    }
    
    private void ChangeHDRI(DateTime currentTime, TimeSpan sunriseTime, TimeSpan sunsetTime,NightType currentNightType)
    {
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            RenderSettings.skybox = dayHdri;
            RenderSettings.fog = false;
            RenderSettings.skybox.SetColor("_Tint", Color.grey);

        }
        else
        {
            SetHDRIColor(currentNightType);
            // RenderSettings.fog = true;
            RenderSettings.skybox = nightHdri;
           
                
        }
    }
}