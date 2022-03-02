using UnityEngine;

public class CheckInteractStatus : MonoBehaviour {
    public void CheckInteractStatue(bool IsInteracted,GameObject interactedGameobject,GameObject unInteractedGameobject)
    {
        if (IsInteracted)
        {
            interactedGameobject.SetActive(true);
            unInteractedGameobject.SetActive(false);
        }
        else
        {
            interactedGameobject.SetActive(false);
            unInteractedGameobject.SetActive(true);
        }
    }
}