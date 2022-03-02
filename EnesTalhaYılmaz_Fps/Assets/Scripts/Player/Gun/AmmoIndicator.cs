using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class AmmoIndicator : MonoBehaviour
{
    TextMeshPro ammoText;
    MagStatus magStatus;
    void Awake(){
        magStatus = GetComponent<MagStatus>();
        ammoText=GetComponentInChildren<TextMeshPro>();
    }
   public void changeAmmoTextColor(Color colorInput){
        ammoText.color=colorInput;
    }
    public void UpdateAmmoText(){
        ammoText.text=magStatus.CurrentAmmo.ToString();
    }
    
}
}

