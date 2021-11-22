using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
   // public GameObject powerupPrefab;
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
       // SpawnPowerUp();

    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        //float zPos = Random.Range(spawnZMin, spawnZMax);
        float zPos = Random.Range(spawnPosZ, spawnPosZ);
        return new Vector3(xPos, spawnPosY, zPos);
    }

    void SpawnZombies()
    {
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);

        Instantiate(zombiePrefabs[zombieIndex], GenerateSpawnPosition(), zombiePrefabs[zombieIndex].transform.rotation);
    }

    /* void SpawnPowerUp()
     {
         Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

         // If no powerups remain, spawn a powerup
         if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
         {
             Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
         }

     } 
    */
}
