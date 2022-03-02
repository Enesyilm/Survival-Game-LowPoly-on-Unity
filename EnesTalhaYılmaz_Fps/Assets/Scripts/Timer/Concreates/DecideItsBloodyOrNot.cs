using UnityEngine;

namespace Timer{
public class DecideItsBloodyOrNot : MonoBehaviour {
    int countDays=0;
    NightType currentdayType;
    public NightType DecidingDayBloodyOrNot(int daysPerBloodyMoon,DayTimes dayTime,AudioSource audioSource)
        {
            if (countDays > daysPerBloodyMoon && dayTime == DayTimes.Sunrise)
            {
                SoundManager.Instance.PlaySound(SoundType.BloodymoonMorning, audioSource);
                currentdayType = NightType.BloodyMoon;
                countDays = 0;
                return currentdayType;
            }
            else if (countDays <= daysPerBloodyMoon && dayTime == DayTimes.Sunrise)
            {
                currentdayType = NightType.NormalNight;
                countDays++;
                SoundManager.Instance.PlaySound(SoundType.NormalMorning, audioSource);
                return currentdayType;

            }
            else if (currentdayType == NightType.NormalNight && dayTime == DayTimes.Sunset)
            {
                SoundManager.Instance.PlaySound(SoundType.NormalEvening, audioSource);
            }
            else if (currentdayType == NightType.BloodyMoon && dayTime == DayTimes.Sunset)
            {
                SoundManager.Instance.PlaySound(SoundType.BloodymoonEvening, audioSource);
            }
            return currentdayType;
        }

}
}