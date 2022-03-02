using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnesTalhaYılmaz_Fps.Movement{
public class OnWaterPreventation : MonoBehaviour
{   bool isOnWater;
    [SerializeField] LayerMask seaMask;
    GameObject PlayerSpawnPoint;
    public void OnWaterPrevention(CharacterController playerController,Transform groundCheck,float groundDistance){
        isOnWater=Physics.CheckSphere(groundCheck.position,groundDistance,seaMask);
        if(isOnWater){
            Debug.Log("Water Is restricted!!");
            playerController.enabled = false;
            PlayerSpawnPoint=GameObject.FindWithTag("PlayerSpawnPoint");
            playerController.transform.position = PlayerSpawnPoint.transform.position;
            playerController.enabled = true;

        }
    }
}
}
