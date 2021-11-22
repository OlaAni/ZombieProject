using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public GameObject[] ammoPrefab;
    private float spawnRangeX = -15;
    private float spawnPosZ = -5;
    private float spawnPosY = 1;
    private float startDelay = 2;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZombies", startDelay, spawnInterval);
        InvokeRepeating("SpawnAmmo", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        // SpawnPowerUp();

    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float yPos = Random.Range(spawnPosY, spawnPosY);
        float zPos = Random.Range(spawnPosZ, spawnPosZ);
        return new Vector3(xPos, yPos, zPos);
    }

    void SpawnZombies()
    {
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);

        Instantiate(zombiePrefabs[zombieIndex], GenerateSpawnPosition(), zombiePrefabs[zombieIndex].transform.rotation);
    }

    void SpawnAmmo()
    {
        int ammoIndex = Random.Range(0, zombiePrefabs.Length);


        Instantiate(ammoPrefab[ammoIndex], GenerateSpawnPosition(), ammoPrefab[ammoIndex].transform.rotation);

    }
}
