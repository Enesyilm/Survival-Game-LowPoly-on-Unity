using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ResourceType{
    WoodAmount,
    EnergyAmount,
    HealthAmount,
}
public enum OperatorType{
    Inc,
    Dec
}
public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    [SerializeField]ResourceTypes[] resourceTypeScriptableObjects;
    [SerializeField] int WoodAmount=0;
    [SerializeField] public  int EnergyAmount=100;
    [SerializeField] public  int HealthAmount=100;
    [Header("ResourceTexts")]
    [SerializeField] TextMeshProUGUI WoodAmountText;
    [SerializeField] TextMeshProUGUI EnergyAmountText;
    [SerializeField] TextMeshProUGUI HealthAmountText;
    public Dictionary<ResourceTypes,int> resources;
    
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
        resources=new Dictionary<ResourceTypes, int>();
        for(int index=0;index<resourceTypeScriptableObjects.Length;index++){
            resources.Add(resourceTypeScriptableObjects[index],resourceTypeScriptableObjects[index].startAmount);
        }
        MapAllResourceTypes();
    }
   
    public void ChangeResAmount(ResourceTypes resourceTypeSO,int amount,OperatorType operatorType){
        
       if(resources.ContainsKey(resourceTypeSO)){
           switch(operatorType){
               case OperatorType.Inc:     
                    resources[resourceTypeSO]+=amount;            
                    if(resourceTypeSO.IsHaveLimitAmount&&resourceTypeSO.maxAmount<=resources[resourceTypeSO]){
                        resources[resourceTypeSO]=resourceTypeSO.maxAmount;
                    }
                    break;
               case OperatorType.Dec:
                    resources[resourceTypeSO]-=amount;
                    break;
           }
            MapAllResourceTypes();
       }
   }
    private void MapAllResourceTypes()
     {
        foreach(ResourceTypes resourceItem in resourceTypeScriptableObjects){
            switch (resourceItem.resourceType)
           {
               case ResourceType.EnergyAmount:
                   EnergyAmount =resources[resourceItem];
                   EnergyAmountText.text=EnergyAmount.ToString();      
                   break;
               case ResourceType.WoodAmount:
                    WoodAmount =resources[resourceItem];
                    WoodAmountText.text=WoodAmount.ToString();
                   break;
               case ResourceType.HealthAmount:
                    HealthAmount =resources[resourceItem];
                    HealthAmountText.text=HealthAmount.ToString();
                   break;
           }
            
        }
    }
    public void UpdateResourceTexts(){
        // EnergyAmount;

    }
   
}