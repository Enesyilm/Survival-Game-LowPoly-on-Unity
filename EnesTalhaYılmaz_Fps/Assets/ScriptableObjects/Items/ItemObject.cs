using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Food,
    Equipment,
    Default
}
public enum ItemName{
    Axe,
    Pickaxe,
    Sword,
    Torch,
    Pistol,
    M416,
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public ItemName itemName;
    [TextArea(15,20)]
    public string description;
}
