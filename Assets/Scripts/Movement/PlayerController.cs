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
    public int AmmoCount = 50;
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
        /*timer += Time.deltaTime;
        if (timeDelay < timer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootBullet();
                timer = 0;
            }
        }*/
        //Debug.Log("Time until nex shot is "+Mathf.RoundToInt(timer));

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * z);
        transform.Translate(Vector3.right * Time.deltaTime * speed * x);

        ammoText.text = "Ammo: " + AmmoCount;
    }

    /*void ShootBullet() 
    {
        if (AmmoCount > 0)
        {
                Instantiate(bullet, transform.position, transform.rotation);
                AmmoCount--;
        }
    }*/

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