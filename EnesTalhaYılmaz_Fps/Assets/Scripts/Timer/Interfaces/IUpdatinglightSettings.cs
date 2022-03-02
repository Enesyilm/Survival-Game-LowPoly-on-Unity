using Timer;
using UnityEngine;

public interface IUpdatinglightSettings
{
    void UpdatelightSettings(Light sunLight, AnimationCurve lightChangeCurve,NightType nightType);
}
