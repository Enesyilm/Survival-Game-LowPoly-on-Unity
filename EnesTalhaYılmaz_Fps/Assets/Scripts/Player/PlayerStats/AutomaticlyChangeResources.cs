using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticlyChangeResources : MonoBehaviour
{
    Timer.WaitForTime waitForTime;
    [SerializeField] ResourceTypes[] regenereableResources;
    [SerializeField] OperatorType[] operatorTypes;
    [SerializeField] int regenerationOffsetTime; 
    [SerializeField] int[] regenerationAmount; 
    private void Awake() {
        waitForTime= new Timer.WaitForTime();
    }
    void Update()
    {
        Regenerate();

    }

    private void Regenerate()
    {
        if (waitForTime.WaitForSec(regenerationOffsetTime))
        {
            ChangeForeachResources.ChangeForeachResource(regenereableResources,operatorTypes,regenerationAmount);
        }
    }
}
