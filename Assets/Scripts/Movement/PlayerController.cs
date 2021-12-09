using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 100f;
    private Rigidbody playerRb;
    public bool isDead = false;

    [Header("Gun Settings")]
    public int AmmoCount1 = 50;
    public int AmmoCount2 = 100;
    public TextMeshProUGUI ammoText;

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
            float z = Input.GetAxis("Vertical");// movement for player


            Vector3 move = new Vector3(x, 0, z).normalized;//stops the playe from ghoin faster when moving diagonally 


            //transform.Translate(Vector3.forward * Time.deltaTime * speed * z);
            // transform.Translate(Vector3.right * Time.deltaTime * speed * x);

            transform.Translate(move * speed * Time.deltaTime);
        }

        //Weapon swtich logic

        if (isSwitched) 
        {
            ammoText.text = "Shotgun: " + AmmoCount1 + "/100";
        }
        else 
        {
            ammoText.text = "Pistol: " + AmmoCount2 + "/50";
        }

        SwitchWeapon();

    }
    private void OnTriggerEnter(Collider other)
    {
        AmmoPickup(other);

        if (other.gameObject.CompareTag("Enemy")) 
        {
            isDead = true;
        }        
        
        if (other.gameObject.CompareTag("Walls")) 
        {
            transform.position = new Vector3(500, 1, 500);
        }


    }

    private void AmmoPickup(Collider other) //ammo pickup
    {
        if (other.gameObject.CompareTag("Ammo") && !(AmmoCount1 == 100))
        {
            Destroy(other.gameObject);
            AmmoCount1 += 5;
            AmmoCount1 = Mathf.Clamp(AmmoCount1, 0, 100);
            Debug.Log("Shotgun replen");
            gunAudio.PlayOneShot(reloadAudio, 1.0f);
        }
        else if (other.gameObject.CompareTag("Ammo2") && !(AmmoCount2 == 50))
        {
            Destroy(other.gameObject);
            AmmoCount2 += 10;
            AmmoCount2 = Mathf.Clamp(AmmoCount2, 0, 50);
            Debug.Log("Auto Replen");
            gunAudio.PlayOneShot(reloadAudio, 1.0f);

        }
    }


    private void SwitchWeapon() //changes acrive weapon
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