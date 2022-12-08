using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] npcs;
    public float cooldownTime;
    private int randomPoint;
    private int randomChar;
    
    void Start()
    {
        randomPoint = Random.Range(0, spawnPoints.Length);
        randomChar = Random.Range(0, npcs.Length);
        SpawnNewEnemy();
        InvokeRepeating("SpawnNewEnemy", cooldownTime,cooldownTime);
    }

    void SpawnNewEnemy()
    {
        randomPoint = Random.Range(0, spawnPoints.Length);
        randomChar = Random.Range(0, npcs.Length);
        GameObject temp = Instantiate(npcs[randomChar], spawnPoints[randomPoint].position, quaternion.identity);
        Destroy(temp,10f);
    }
    
    
}
