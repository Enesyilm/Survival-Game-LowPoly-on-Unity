using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName=" New Food Object",menuName="Inventory System/Items/Food Object")]

public class FoodObject : ItemObject
{
    [Range(0,100)]public int restoreHealthValue;
    private void Awake() {
        type=ItemType.Food;
        
    }
}
