using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.EnemyShips{
public class ShipMovement : MonoBehaviour
{
    ShipController shipController;

    ShipSpawnPoints.CheckSpawnPointsType checkSpawnPointsType;
    Transform allShipSpawnPoints;
    [SerializeField] float shipSpeed=0.5f;
    ShipSpawnPoints.SpawnPointState currentSpawnPointState;
    
    Vector3 directionToFace;
    int index=1;
    void Awake()
    {
        
        checkSpawnPointsType=GetComponent< ShipSpawnPoints.CheckSpawnPointsType>();
        shipController=GetComponentInParent<ShipController>();
        allShipSpawnPoints=shipController.ShipSpawner.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnPointState=allShipSpawnPoints.transform.GetChild(index).GetComponent<ShipSpawnPoints.SpawnPointState>();
        MoveTarget();
        if(directionToFace==Vector3.zero){
            index=checkSpawnPointsType.CheckSpawnPointType(currentSpawnPointState,index,allShipSpawnPoints);
        }
    }

    
    
    void MoveTarget(){
            directionToFace=allShipSpawnPoints.GetChild(index).transform.position-transform.position;
            gameObject.transform.rotation=Quaternion.LookRotation(directionToFace);
            gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position,allShipSpawnPoints.GetChild(index).position,shipSpeed);
                
            }
}
}

