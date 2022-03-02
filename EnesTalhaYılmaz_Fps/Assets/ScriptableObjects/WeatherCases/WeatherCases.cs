using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weather Case",menuName ="Weather Case")]
public class WeatherCases : ScriptableObject
{
    [SerializeField] public CurrentWeatherType WeatherType;
    [SerializeField] public GameObject weatherObject;
    [SerializeField] public Vector3 SpawnPoint;
    [SerializeField] public Vector3 SpawnPointRotation;
}
