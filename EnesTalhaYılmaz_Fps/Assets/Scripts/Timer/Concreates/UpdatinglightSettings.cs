using UnityEngine;

namespace Timer{
public class UpdatinglightSettings : MonoBehaviour, IUpdatinglightSettings
{
    [SerializeField] Color dayAmbientlight;
    [SerializeField] Color nightAmbientlight;
    [SerializeField] Color bloodyNightAmbientlight;
    [SerializeField] float maxSunLightIntensity;
    [SerializeField] float maxMoonLightIntensity;
    [SerializeField] Light moonLight;

    public void UpdatelightSettings(Light sunLight, AnimationCurve lightChangeCurve,NightType nightType)
        {
            if (nightType == NightType.NormalNight)
            {
                ChangeLightIntensity(sunLight, lightChangeCurve,nightAmbientlight);

            }
            else if(nightType == NightType.BloodyMoon){
                ChangeLightIntensity(sunLight, lightChangeCurve,bloodyNightAmbientlight);

            }
        }

        private void ChangeLightIntensity(Light sunLight, AnimationCurve lightChangeCurve,Color nightAmbientlightParam)
        {
            float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
            sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
            moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
            RenderSettings.ambientLight = Color.Lerp(nightAmbientlightParam, dayAmbientlight, lightChangeCurve.Evaluate(dotProduct));
        }
    }
}