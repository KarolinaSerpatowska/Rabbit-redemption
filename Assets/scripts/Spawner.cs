using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    public GameObject objectToSpawn;
    GameObject[] spawnPoints;
    public int howManyEnemiesShouldBeSpawn;

    static int howManyEnemiesWereSpawned;

    private void SpawnObject()
    {
        int pointNumber = Random.Range(0, spawnPoints.Length);
        Instantiate(objectToSpawn, spawnPoints[pointNumber].transform.position, Quaternion.identity, transform);
        howManyEnemiesWereSpawned++;
    }

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawner");
        howManyEnemiesWereSpawned = 0;
    }


    void FixedUpdate()
    {
        if (howManyEnemiesWereSpawned == 0)
        {
            for (int i = 0; i < howManyEnemiesShouldBeSpawn; ++i)
                SpawnObject();
        }
    }
}