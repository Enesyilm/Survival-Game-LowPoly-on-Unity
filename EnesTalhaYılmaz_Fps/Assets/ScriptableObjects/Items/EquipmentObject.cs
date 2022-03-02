using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName=" New Equipment Object",menuName="Inventory System/Items/Equipment Object")]

public class EquipmentObject : ItemObject
{
    public  int AttackPoint=10;
    public  int DefencePoint=0;
    public  int Durability=100;
    private void Awake() {
        type=ItemType.Equipment;
        
    }
}
