using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireEvent : MonoBehaviour,IInteractionEvent
{
    [SerializeField]AudioSource audioSource;
    bool IscampFireActive=false;
    private void Awake() {
        
    }
    public bool SpesificInteraction(){
        IscampFireActive=true;
        if(IscampFireActive){
        SoundManager.Instance.PlaySound(SoundType.CampFireSound,audioSource);
        }
        else{
            audioSource.Stop();
        }
            return true;
    }
    

}
