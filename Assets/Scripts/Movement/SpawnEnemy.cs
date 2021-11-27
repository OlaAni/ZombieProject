using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public GameObject[] ammoPrefab;

    public float spawnRangeX = -15;
    public float spawnPosZ = -5;
    public float spawnPosY = 1;
    private float startDelay = 2;
    private float spawnInterval = 2f;

    public PlayerController playerController;

    public GameObject playerPos;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();


        InvokeRepeating("SpawnAmmo", startDelay, spawnInterval);
        //InvokeRepeating("SpawnZombies", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(spawnRangeX, spawnRangeX + 300);
        float zPos = Random.Range(spawnPosZ, spawnPosZ + 300);
        return new Vector3(xPos, spawnPosY, zPos);
    }


    Vector3 GenerateAmmoPosition()
    {
        float xPos = Random.Range(5, 20);
        float zPos = Random.Range(5, 20);

        return new Vector3(playerPos.transform.position.x + xPos, spawnPosY, playerPos.transform.position.z + zPos);
    }

    void SpawnZombies()
    {
        if (!playerController.isDead)
        {
            int zombieIndex = Random.Range(0, zombiePrefabs.Length);

            for (int i = 0; i < 5; i++)
            {
                Instantiate(zombiePrefabs[zombieIndex], GenerateSpawnPosition(), zombiePrefabs[zombieIndex].transform.rotation);
            }
        }
    }



    void SpawnAmmo()
    {
        if (!playerController.isDead)
        {
            int ammoIndex = Random.Range(0, ammoPrefab.Length);
            Debug.Log(ammoIndex);

            Instantiate(ammoPrefab[ammoIndex], GenerateAmmoPosition(), ammoPrefab[ammoIndex].transform.rotation);
        }
    }

}