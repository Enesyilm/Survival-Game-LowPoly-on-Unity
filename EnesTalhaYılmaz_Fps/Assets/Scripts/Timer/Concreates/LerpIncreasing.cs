using UnityEngine;

public class LerpIncreasing  {
    public float timeElapsed=0;
    float lerpDuration=5;
    public float LerpIncreaser(float ToThisExposureValue,float fromThisExposure)
    {   
        if (timeElapsed < lerpDuration)
        {
            fromThisExposure = Mathf.Lerp(fromThisExposure,ToThisExposureValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        return fromThisExposure;
    }

}