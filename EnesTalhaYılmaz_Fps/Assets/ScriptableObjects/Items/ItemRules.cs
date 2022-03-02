using System.Collections.Generic;
using UnityEngine;

public static class ItemRules{
    public static Dictionary<int,ItemType> meleeWeapons=new Dictionary<int, ItemType>();
    public static ItemType[] RangeWeapons;
    public static ItemName CurrentItemOnHand;
}