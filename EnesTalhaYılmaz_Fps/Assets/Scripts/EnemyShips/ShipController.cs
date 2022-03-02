using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.EnemyShips{
public class ShipController : MonoBehaviour
{
    [SerializeField] GameObject ship;
    [Range(0,120)][SerializeField] int shipPerSec;
    float shipTimer=0;
     Transform shipSpawnPoints;

    public Transform ShipSpawner { get => shipSpawnPoints; set => shipSpawnPoints = value; }

        // Start is called before the first frame update
    void Awake(){
        shipSpawnPoints=GameObject.FindWithTag("ShipSpawnPoints").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ShipSpawnTimer();
    }
    void ShipSpawnTimer(){
        if(shipTimer<shipPerSec){
            shipTimer+=Time.deltaTime;
            
        }
        else{
            shipTimer=0;
            CreateShips();
        }
    }
    void CreateShips(){
        Instantiate(ship.transform.GetChild(Random.Range(0,ship.transform.childCount)),shipSpawnPoints.transform.GetChild(0).position,Quaternion.LookRotation(Vector3.back),transform);

    }
}

}