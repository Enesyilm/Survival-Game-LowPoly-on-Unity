using UnityEngine;

public class HotkeyPage : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKeyDown){
            Destroy(gameObject);
        }
        
    }
}
