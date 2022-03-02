using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Movement{
public class Jump : MonoBehaviour
{
    [SerializeField] int jumpHeight=5;
  public float CheckJump(CharacterController playerController,Controllers.PcControllers input,bool isGrounded,Vector3 velocity,float gravity){
        if(input.jumpInput && isGrounded)
        {
            velocity.y =Mathf.Sqrt(jumpHeight*-2f*gravity);
        }
        velocity.y +=gravity*Time.deltaTime;
        playerController.Move(velocity*Time.deltaTime);

        return velocity.y;
    }
}
}

