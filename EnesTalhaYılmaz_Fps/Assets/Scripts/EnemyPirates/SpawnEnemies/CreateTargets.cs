using UnityEngine;
using UnityEngine.UI;

namespace EnesTalhaYılmaz_Fps.EnemyPirates.SpawnEnemies{
public class CreateTargets : MonoBehaviour
{
    [Range(1,5)][SerializeField] int numberOfTargets=1;
    [SerializeField] Transform pirateModels;
    [SerializeField] Transform spawnPoints;
    [SerializeField] int spawnOffset;
    GameObject targetHolder;
    Timer.WaitForTime waitForTime;
    // Text targetAmountText;

    void Awake(){
        waitForTime=new Timer.WaitForTime();
        //targetAmountText=GameObject.FindGameObjectWithTag("TargetAmountText").GetComponent<Text>();
        targetHolder = GameObject.FindGameObjectWithTag("TargetHolder");
    }
    public void SpawnTargets(){
        for(int index=0;index<numberOfTargets;index++){

            if(waitForTime.WaitForSec(spawnOffset)){
                Transform EnemyInstantiate =Instantiate(pirateModels.GetChild(Random.Range(0,pirateModels.childCount)),spawnPoints.GetChild(Random.Range(0,spawnPoints.childCount)).position,Quaternion.LookRotation(Vector3.back),targetHolder.transform);
            }

        }
    }
    // public void UpdateTargetText(){
    //     targetAmountText.text= targetHolder.transform.childCount.ToString();

    // }
}
}

