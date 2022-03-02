using UnityEngine;

namespace Controllers{
public class PcControllers
{
    public bool jumpInput => Input.GetKeyDown(KeyCode.Space);
    public bool RunInput => Input.GetKeyDown(KeyCode.LeftShift);
    public bool semiFireInput=>Input.GetMouseButtonDown(0);
    public bool autoFireInput=>Input.GetMouseButton(0);
    public bool switchWeaponInput=>Input.GetKeyDown(KeyCode.W);
    public bool reloadInput=>Input.GetKeyDown(KeyCode.R);

    //Event
    public bool InteractInput=>Input.GetKeyDown(KeyCode.E);
    public bool InteractInputHold=>Input.GetKey(KeyCode.E);
    public bool renewTargetHealthsInput=>Input.GetKeyDown(KeyCode.V);
    public float horizontal => Input.GetAxis("Horizontal");
    public float vertical => Input.GetAxis("Vertical");
    // Start is called before the first frame update
    
   
}

}
