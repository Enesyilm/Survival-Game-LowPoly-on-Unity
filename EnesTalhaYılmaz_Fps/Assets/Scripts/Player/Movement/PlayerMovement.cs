using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Movement{
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController playerController; 
    [SerializeField] Transform groundCheck; 
    [SerializeField] float groundDistance=0.1f;
    [SerializeField] int speed=10;
    [SerializeField] float gravity =-9.81f;
    [SerializeField]Animator playerAnimator;

    Controllers.PcControllers input;
    OnWaterPreventation onWaterPrevent;
    Jump jump;
    Gravity gravityCheck;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Awake(){
        
        input= new Controllers.PcControllers();
        onWaterPrevent=GetComponent<OnWaterPreventation>();
        gravityCheck=GetComponent<Gravity>();
        jump=GetComponent<Jump>();
        }
    void Update()
    {  
        onWaterPrevent.OnWaterPrevention( playerController, groundCheck, groundDistance);
        var tuple = gravityCheck.GravityCalculate( velocity, gravity, groundCheck, groundDistance,isGrounded);
        velocity.y=tuple.Item1;
        isGrounded=tuple.Item2;
        Movement();
        velocity.y=jump.CheckJump( playerController, input, isGrounded, velocity, gravity);
    }
    void Movement()
        {
            Vector3 move = transform.right * input.horizontal + transform.forward * input.vertical;
            playerController.Move(move * speed * Time.deltaTime);

        }
    }
    

}
