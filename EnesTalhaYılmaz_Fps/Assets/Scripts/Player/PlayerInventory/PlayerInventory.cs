using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] InventoryObject currentInventory;
    [SerializeField] UpdateCurrentItemInHand updateCurrentItemInHand;
    [SerializeField] GameObject currentInventoryUI;
    [SerializeField] Color selectedSlotMaterialColor;
    [SerializeField] Color unSelectedSlotMaterialColor;
    List<InventorySlot> currentInv;
    List<GameObject> activeSlotsUI=new List<GameObject>();
    int prevSelectedSlotIndex=0;
   
    void Awake()
    {
        currentInv=currentInventory.container;
        currentInventory.currentSelectedSlot=0;
        UpdateItemsInUI();
        SendItemToItemHolder(activeSlotsUI,currentInv,currentInventory.currentSelectedSlot);
    }

    private void SendItemToItemHolder(List<GameObject> activeSlotsUI,List<InventorySlot> currentInv,int currentSelectedSlot)
    {
        updateCurrentItemInHand.UpdateCurrentItemInhands(activeSlotsUI,currentInventory.container[currentSelectedSlot],currentInventory.currentSelectedSlot);
    }

    private void Update() {
        SwitchBetweenSlots();
        
        

    }

    void UpdateItemsInUI()
    {   currentInventory.currentSlotSize=0;
        for (int i = 0; i < currentInventory.container.Count; i++)
        {
                currentInventory.currentSlotSize++;
                currentInventoryUI.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < currentInventoryUI.transform.childCount-(currentInventory.container.Count); i++)
        {
             currentInventoryUI.transform.GetChild(i).gameObject.SetActive(false);
        }
        MapActiveSlotsWithUI();
    }
    void SwitchBetweenSlots()
    {
        prevSelectedSlotIndex=currentInventory.currentSelectedSlot;
        if(Input.mouseScrollDelta.y>0){
            currentInventory.currentSelectedSlot++;
            UpdateSlotColors();
            
            if(currentInventory.currentSlotSize-1<currentInventory.currentSelectedSlot)
            {
                currentInventory.currentSelectedSlot = 0;
                
                
            }
            SendItemToItemHolder(activeSlotsUI,currentInv,currentInventory.currentSelectedSlot);

        }
        else if(Input.mouseScrollDelta.y<0){
            currentInventory.currentSelectedSlot--;
            if(0>currentInventory.currentSelectedSlot){
                currentInventory.currentSelectedSlot=currentInventory.currentSlotSize-1;
            }
            UpdateSlotColors();
            SendItemToItemHolder(activeSlotsUI,currentInv,currentInventory.currentSelectedSlot);
            
        }
        
    }

    private void UpdateSlotColors()
    {
        MapActiveSlotsWithUI();
        activeSlotsUI[currentInventory.currentSelectedSlot].GetComponent<Image>().color = selectedSlotMaterialColor;
        activeSlotsUI[prevSelectedSlotIndex].GetComponent<Image>().color = unSelectedSlotMaterialColor;
    }

    private void MapActiveSlotsWithUI()
    {
        int count=0;
        foreach (Transform child in currentInventoryUI.transform)
        {
            if (child.gameObject.activeInHierarchy){
                activeSlotsUI.Add(child.gameObject);
                count++;
            }
        }
    }
}
