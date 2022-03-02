using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    int selectedWeapon=0;
    Controllers.PcControllers input;
    AudioSource audioSource;
    int maxWeaponSize;
    // Update is called once per frame
    void Awake(){
        input =new Controllers.PcControllers();
        audioSource=GetComponent<AudioSource>();
        maxWeaponSize=gameObject.transform.childCount;
    }
    void Update()
    {
        if(input.switchWeaponInput){
        selectedWeapon=SwitchWeaponIndex(selectedWeapon);
        SelectWeapon(selectedWeapon);
        }
        
    }
    int SwitchWeaponIndex(int selectedWeaponParam){    
            selectedWeaponParam++;
            if(selectedWeaponParam>maxWeaponSize-1){
                selectedWeaponParam=0;
            }  
        return selectedWeaponParam;

    }
    void SelectWeapon(int selectedWeaponParam){
        int type=0;
        foreach(Transform weapon in transform){
            if(type==selectedWeaponParam){
                weapon.gameObject.SetActive(true);
                SoundManager.Instance.PlaySound(SoundType.SwitchWeapon,audioSource);
                Debug.Log("weapon switched to :"+ weapon.gameObject.name);
                
            }
            else{
                weapon.gameObject.SetActive(false);
            }
            type++;

        }
    }
}
