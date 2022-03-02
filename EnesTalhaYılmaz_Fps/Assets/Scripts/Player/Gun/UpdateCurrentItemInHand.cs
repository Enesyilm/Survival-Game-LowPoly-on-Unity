using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCurrentItemInHand : MonoBehaviour
{
   GameObject previousItem;
   GameObject currentItem;
   Dictionary<int,GameObject>ItemsOnHand=new Dictionary<int, GameObject>();
   private void Update() {
      
   }
   public void UpdateCurrentItemInhands(List<GameObject> activeSlotsUI,InventorySlot currentSlot,int currentSelectedSlot)
    {
      if(currentItem!=null){
         Debug.Log("is not null");
         previousItem=currentItem;
         previousItem.SetActive(false);
       }
      if(ItemsOnHand.ContainsKey(currentSelectedSlot)){
         Debug.Log("SetActive true");

         currentItem=ItemsOnHand[currentSelectedSlot];
         currentItem.SetActive(true);
         
      }
      if(!ItemsOnHand.ContainsKey(currentSelectedSlot)){
         Debug.Log("new instantiated");
         currentItem = Instantiate(currentSlot.item.prefab, transform.position, transform.rotation, transform);
         ItemsOnHand.Add(currentSelectedSlot,currentItem);
      }
      
      
    }
}
