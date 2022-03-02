using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wall{
public class WallPurchaseEvent : MonoBehaviour,IInteractionEvent
{
    public bool SpesificInteraction(){
            return true;
    }
}
}

