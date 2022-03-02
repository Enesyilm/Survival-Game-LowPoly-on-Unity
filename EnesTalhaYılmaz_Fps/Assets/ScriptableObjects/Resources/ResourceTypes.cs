using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Resource Type",menuName ="Resource Type")]
public class ResourceTypes : ScriptableObject
{
    [SerializeField] public ResourceType resourceType;
    [SerializeField] public int startAmount=0;
    [SerializeField] public bool IsHaveLimitAmount=false;
    [SerializeField] public int maxAmount=100;
}
