using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Animations{
    Walk,
    Idle,
    Chop,
    Jump,
    Run
}
public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    Controllers.PcControllers input;
    EnesTalhaYılmaz_Fps.Gun.Shoot shoot;
    [SerializeField]Animator playerAnimator;
    [HideInInspector]public bool IsChopped=false;
    private void Awake() {
        input= new Controllers.PcControllers();
        playerAnimator=GetComponentInChildren<Animator>();
        shoot=GetComponent<EnesTalhaYılmaz_Fps.Gun.Shoot>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       DecideAnimationType();
    }

    private void DecideAnimationType()
    {
        if(input.jumpInput){
            playerAnimator.SetTrigger("Jump");}
       
        if(PlayerStateBools.IsShooting){
           playerAnimator.SetTrigger("Shoot");
           PlayerStateBools.IsShooting=false;
        }
        if(PlayerStateBools.IsChopping){
            playerAnimator.SetTrigger("Chop");
            PlayerStateBools.IsChopping=false;
        }
        if(PlayerStateBools.IsAttacking){
            playerAnimator.SetTrigger("Chop");
            PlayerStateBools.IsAttacking=false;
        }
        if(input.vertical >= 0.1 || input.horizontal >= 0.1){
           playerAnimator.SetBool("IsWalk",true);
        }
        else if(input.vertical < 0.1 || input.horizontal < 0.1){
           playerAnimator.SetBool("IsWalk",false);
        }

    }
}
