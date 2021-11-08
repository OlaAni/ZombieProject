using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 12f;
    private Rigidbody playerRb;
    public bool isDead = false;

    [Header("Gun Settings")]
    public float offSet;
    public int AmmoCount = 5;
    public TextMeshProUGUI ammoText;
    public GameObject bullet;
    private float timeDelay = 1.0f;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timeDelay < timer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootBullet();
                timer = 0;
            }
        }
        //Debug.Log("Time until nex shot is "+Mathf.RoundToInt(timer));

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * z);
        transform.Translate(Vector3.right * Time.deltaTime * speed * x);

        ammoText.text = "Ammo: " + AmmoCount;
    }

    void ShootBullet() 
    {
        if (AmmoCount > 0)
        {
                Instantiate(bullet, transform.position, transform.rotation);
                AmmoCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo")) 
        {
            Destroy(other.gameObject);
            AmmoCount = 5;
            //Debug.Log("Ammo replen");
        }

        if (other.gameObject.CompareTag("Enemy")) 
        {
            isDead = true;
        }
    }
}

/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    private float spawnRangeX = -15;
    private float spawnPosZ = -5;
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
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);

        Instantiate(zombiePrefabs[zombieIndex], spawnPos, zombiePrefabs[zombieIndex].transform.rotation);
    }
}
*/