using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnesTalhaYılmaz_Fps.ShipSpawnPoints{
public enum SpawnPointType{
    WaitAtSpawnPoint,
    PassThrought,
    Destroy

}
public class SpawnPointState : MonoBehaviour
{
        [SerializeField] private SpawnPointType spawnPointType;
        [SerializeField] public int waitingSecAtSpawnPoint=1;

        public SpawnPointType SpawnPointType { get => spawnPointType; set => spawnPointType = value; }

}


}
