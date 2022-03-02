using UnityEngine;

public class CheckResourcesCanChangeFromInteract : MonoBehaviour {
    bool canSuccesfulyChange=false;
    public bool ForeachCanChangeResources(ResourceTypes[] requriedResourceType,OperatorType[] operatorType,int[] requriedResourceAmounts){
            int index=0;
            foreach(ResourceTypes resourceItem in requriedResourceType){
                canSuccesfulyChange=CanChangeValue(resourceItem,requriedResourceAmounts[index],operatorType[index]);
                if(!canSuccesfulyChange){
                    return false;
                }
                index++;
            }
             return true;
    }
    
    public bool CanChangeValue(ResourceTypes resourceTypeSO,int amount,OperatorType operatorType)
        {
            
            switch(operatorType){
               case OperatorType.Dec:
                    if (ResourceManager.Instance.resources[resourceTypeSO] >= amount)
                    {
                        return true;//iobg
                    }
                    else
                    {
                        return false;
                    }
                case OperatorType.Inc:
                    return true;
            }
            return false;
        }
}