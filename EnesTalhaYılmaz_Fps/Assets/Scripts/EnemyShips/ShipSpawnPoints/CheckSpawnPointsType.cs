using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.ShipSpawnPoints{
public class CheckSpawnPointsType :MonoBehaviour
{
    Timer.WaitForTime waitClass;
    EnemyPirates.SpawnEnemies.CreateTargets createTargets;
    private void Awake() {
        createTargets=GetComponentInChildren<EnemyPirates.SpawnEnemies.CreateTargets>();
        waitClass=new Timer.WaitForTime();
    }
   public int CheckSpawnPointType(SpawnPointState currentSpawnPointState,int index,Transform allShipSpawnPoints){
            switch(currentSpawnPointState.SpawnPointType)
             {
            case SpawnPointType.WaitAtSpawnPoint:
            {
                createTargets.SpawnTargets();
                if(waitClass.WaitForSec(currentSpawnPointState.waitingSecAtSpawnPoint))
                {
                    index++;
                };
                return index;
            }
            case SpawnPointType.PassThrought:
            {
          
                index=(index+1)<allShipSpawnPoints.childCount?index++:index;
                return index;
            }
            case SpawnPointType.Destroy:
            {
                Destroy(gameObject);
                return index;
            }
            default:
                return index;
            }
        }
    
    }
}

