using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Movement{
public class Gravity : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    public Tuple<float, bool> GravityCalculate(Vector3 velocity,float gravity,Transform groundCheck,float groundDistance,bool isGrounded){
        velocity.y +=gravity*Time.deltaTime;
        isGrounded=Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if(isGrounded && velocity.y<0){
             velocity.y=-2f;
        }
        return new Tuple<float, bool>(velocity.y, isGrounded);
    }
}

}
