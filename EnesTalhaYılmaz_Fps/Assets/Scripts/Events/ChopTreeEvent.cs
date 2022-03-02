using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChopTreeEvent : MonoBehaviour,IInteractionEvent
{
    
    [SerializeField]int chopNumberForCut=4;//wrıte an general resource mınıng scrıpt for tree stone and the
    [SerializeField]int currentNumberForCut;
    [SerializeField]GameObject fallingPartOfTree;
    AudioSource audioSource;
    [Range(0,1)] float lerpValue=0;
    bool isFalling=false;
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
        currentNumberForCut=chopNumberForCut;
    }
    void Update() {
        
        if(isFalling){
            FallTheTree();
        }
    }
    public bool SpesificInteraction(){
        currentNumberForCut--;
        PlayerStateBools.IsChopping=true;
        SoundManager.Instance.PlaySound(SoundType.PlayerChopTree,audioSource);
        if(currentNumberForCut<=0){
            isFalling=true;
            return true;
        }
        else{
            return false;
    }
    }
    public void FallTheTree(){
        SoundManager.Instance.PlaySound(SoundType.TreeFall,audioSource);
        GameObject fallingPartOfTreeInstance =Instantiate(fallingPartOfTree,transform.position,Quaternion.identity);
        Rigidbody RigidbodyOfInstance=fallingPartOfTreeInstance.AddComponent<Rigidbody>(); // Add the rigidbody.
        RigidbodyOfInstance.constraints = RigidbodyConstraints.FreezeRotationY; // Set the GO's mass to 5 via the Rigidbody
        fallingPartOfTreeInstance.SetActive(true);
        fallingPartOfTreeInstance.transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler((Random.Range(0,2) * 2 - 1)*Random.Range(40,90),(Random.Range(0,2) * 2 - 1)*Random.Range(40,90),0),.1f);
        isFalling=false;
        Destroy(fallingPartOfTreeInstance,10f);

    }
}
