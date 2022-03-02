using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalenderTextUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI elapsedDaysText;
     [SerializeField] TextMeshProUGUI dayHourText;
     [SerializeField] Timer.DayNightCycle dayNightCycle;
     private void Awake() {
         dayNightCycle=GetComponent<Timer.DayNightCycle>();
     }
    void Update()
    {
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        elapsedDaysText.text = DayCounter.elapsedDays.ToString();
        if (dayHourText != null)
        {
            dayHourText.text = dayNightCycle.currentTime.ToString("HH:mm");
        }
    }
}
