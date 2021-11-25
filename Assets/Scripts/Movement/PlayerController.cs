using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 20f;
    private Rigidbody playerRb;
    public bool isDead = false;

    [Header("Gun Settings")]
    public int AmmoCount1 = 50;
    public int AmmoCount2 = 100;
    public TextMeshProUGUI ammoText;
    private float timeDelay = 1.0f;
    private float timer;

    [Header("Ammo Sounds")]
    private AudioSource gunAudio;
    public AudioClip reloadAudio;



    [Header("Gun Switching")]
    public GameObject gun1;
    public GameObject gun2;
    public bool isSwitched = true;



    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * z);
            transform.Translate(Vector3.right * Time.deltaTime * speed * x);
        }

        if (isSwitched) 
        {
            ammoText.text = "Ammo1: " + AmmoCount1 + "/50";
        }
        else 
        {
            ammoText.text = "Ammo2: " + AmmoCount2 + "/100";
        }

        SwitchWeapon();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo")) 
        {
           // if (AmmoCount1 >= 50)
           // {
            Destroy(other.gameObject);
            AmmoCount1 += 5;
            AmmoCount1 = Mathf.Clamp(AmmoCount1, 0, 50);
            Debug.Log("Shotgun replen");
            gunAudio.PlayOneShot(reloadAudio, 1.0f);

            //}
        }
        else if (other.gameObject.CompareTag("Ammo2"))
        {
            Destroy(other.gameObject);
            AmmoCount2 += 10;
            AmmoCount2 = Mathf.Clamp(AmmoCount2, 0, 100);
            Debug.Log("Auto Replen");
            gunAudio.PlayOneShot(reloadAudio, 1.0f);

        }

        if (other.gameObject.CompareTag("Enemy")) 
        {
            isDead = true;
        }


    }


    private void SwitchWeapon() 
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0 ) && isSwitched == true) 
        {
            Debug.Log("1");
            gun1.SetActive(false);
            gun2.SetActive(true);
            isSwitched = false;
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") < 0) && isSwitched == false)
        {
            Debug.Log("2");
            gun1.SetActive(true);
            gun2.SetActive(false);
            isSwitched = true;
        }
    }
}


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


/*void ShootBullet() 
{
    if (AmmoCount > 0)
    {
            Instantiate(bullet, transform.position, transform.rotation);
            AmmoCount--;
    }
}*/