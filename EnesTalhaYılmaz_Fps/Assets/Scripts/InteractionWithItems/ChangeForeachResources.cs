using UnityEngine;

public static class ChangeForeachResources {
    public static void ChangeForeachResource(ResourceTypes[] requriedResourceType,OperatorType[] operatorType,int[] requriedResourceAmounts){
        int index=0;
        foreach(ResourceTypes resourceItem in requriedResourceType){
            if(operatorType.Length==1){
                int useSameOperatorToOthers=0;
                ResourceManager.Instance.ChangeResAmount(resourceItem,requriedResourceAmounts[index],operatorType[useSameOperatorToOthers]);
            }
            else{
                ResourceManager.Instance.ChangeResAmount(resourceItem,requriedResourceAmounts[index],operatorType[index]);
            }
            
            index++;
        }
    }
}