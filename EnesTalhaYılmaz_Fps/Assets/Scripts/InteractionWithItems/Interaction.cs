using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PressType{
    Hold,
    Press
}
public class Interaction : MonoBehaviour
{
    [Header("Need an script that herits from IInteractionEvent to work properly")]

    [SerializeField]OperatorType[] operatorType;
    [SerializeField]ResourceTypes[] requriedResourceType;
    CheckResourcesCanChangeFromInteract checkCanChangeResources;
    CheckInteractStatus checkInteractStatus;
    CheckOffsetTime checkInteractionOffsetTimes;
    [SerializeField]int[] requriedResourceAmounts;
    [SerializeField]int EventOffset=1;
    [SerializeField] PressType pressType;
    [SerializeField] Vector3 boxSize;
    [SerializeField] Vector3 offsetSize;
    [SerializeField] GameObject interactedGameobject;
    [SerializeField] GameObject unInteractedGameobject;
    IInteractionEvent interactionEvent;
    [SerializeField] LayerMask player;
    Controllers.PcControllers input;
    bool isInput=false;
    // bool canInteract=true;
    bool IsInteracted=false;
    // Start is called before the first frame update
    void Awake()
    {
        interactionEvent=GetComponent<IInteractionEvent>();
        checkCanChangeResources=GetComponent<CheckResourcesCanChangeFromInteract>();
        checkInteractStatus=GetComponent<CheckInteractStatus>();
        checkInteractionOffsetTimes=new CheckOffsetTime();
        input=new Controllers.PcControllers();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(checkInteractionOffsetTimes.CheckInteractionOffsetTimes(EventOffset)){
            Interact(interactionEvent);
        }
        checkInteractStatus.CheckInteractStatue(IsInteracted, interactedGameobject, unInteractedGameobject);
        InputType();


    }
    private void InputType()
    {
        switch (pressType)
        {
            case PressType.Hold:
                isInput = input.InteractInputHold;
                break;
            case PressType.Press:
                isInput = input.InteractInput;
                break;
        }
    }

    

    

    private void Interact(IInteractionEvent interactionEvent)
    {
        if (Physics.CheckBox(transform.position + offsetSize, boxSize, Quaternion.identity, player) && isInput && IsInteracted==false&& checkCanChangeResources.ForeachCanChangeResources(requriedResourceType,operatorType,requriedResourceAmounts))
        {
            checkInteractionOffsetTimes.canInteract=false;
            if(interactionEvent.SpesificInteraction()){
                ChangeForeachResources.ChangeForeachResource(requriedResourceType,operatorType,requriedResourceAmounts);
                IsInteracted=true;
                
                
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube(transform.position+offsetSize,boxSize*2);
    }
}
