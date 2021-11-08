using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    private float spawnRangeX = -15;
    private float spawnPosZ = -5;
    private float spawnPosY = 5;
    private float startDelay = 2;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZombies", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnZombies()
    {
        //Randomly generate zombie index and spawn location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);

        Instantiate(zombiePrefabs[zombieIndex], spawnPos, zombiePrefabs[zombieIndex].transform.rotation);
    }
}
