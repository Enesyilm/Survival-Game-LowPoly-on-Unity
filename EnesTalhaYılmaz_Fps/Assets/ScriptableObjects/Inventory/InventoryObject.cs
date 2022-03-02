using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName=" New Equipment Object",menuName="Inventory System/Inventory/Equipment Object")]

public class InventoryObject : ScriptableObject
{
   [SerializeField]public List<InventorySlot> container=new List<InventorySlot>();
   public int maxSlotSize=0;
   public int currentSlotSize=0;
   public int currentSelectedSlot=0;
   public void CheckIfItemAlreadyExist(ItemObject _item,int _amount){
       bool hasItem = false; 
        for (int i = 0; i < container.Count; i++){
            if(container[i].item == _item)
            {
                container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            container. Add(new InventorySlot(_item, _amount));
        }
    }
    
}
[System.Serializable]
public class InventorySlot{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item,int _amount){
        item=_item;
        amount=_amount;
    }
    public void AddAmount(int value){
        amount+=value;
    }
}