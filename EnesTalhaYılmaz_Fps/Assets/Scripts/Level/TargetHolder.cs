using UnityEngine;

public class TargetHolder : MonoBehaviour
{
    [Range(1,6)][SerializeField] int targetAmount;
    [SerializeField] Transform pirateModels;
    [SerializeField] Transform spawnPoints;
    void createTarget(int targetAmount){
        if(gameObject.transform.childCount==0){
             for(int index=0;index<targetAmount;index++){
            Instantiate(pirateModels.GetChild(Random.Range(0,pirateModels.childCount)),spawnPoints.GetChild(index).position,Quaternion.LookRotation(Vector3.back),transform);
            }
        }
    }
}
