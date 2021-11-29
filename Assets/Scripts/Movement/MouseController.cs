using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    [Header("Mouse Settings")]
    public float mouseSpeed = 200f;
    public Transform playerGameObject;
    public float LookUp = 0f;


    [Header("Gun Sounds")]
    private AudioSource gunAudio;
    public AudioClip shotgunSound;
    public AudioClip autoSound;
    public AudioClip emptySound;


    [Header("Gun Settings")]
    //private float timeDelay = 1.0f;
    //private float timer;
    public GameObject bullet1;
    public GameObject bullet2;
    public PlayerController playerController;
    public Vector3 offset = new Vector3(0,0,0);

    public Vector3 spread = new Vector3(1,0,0);
    public Vector3 negspread = new Vector3(-1,0,0);



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Hides tHE CURSOR
        gunAudio = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isDead)
        {
            ShootBullet();


            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

            LookUp = LookUp - mouseY;//
            LookUp = Mathf.Clamp(LookUp, -90f, 90f);//stops the camera from rotating to far up or down

            transform.localRotation = Quaternion.Euler(LookUp, 0f, 0f);//rotates the camera around y axis
            playerGameObject.Rotate(Vector3.up * mouseX);//rotates the player around the x axis
        }


    }


    public void ShootBullet() 
    {
        if (playerController.isSwitched)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (playerController.AmmoCount1 > 0)
                {
                    Instantiate(bullet1, transform.position , transform.rotation);
                    Instantiate(bullet1, transform.position + spread  , transform.rotation);
                    Instantiate(bullet1, transform.position + negspread  , transform.rotation);
                    gunAudio.PlayOneShot(shotgunSound, 1.0f);


                    playerController.AmmoCount1--;
                }
                else 
                {
                    gunAudio.PlayOneShot(emptySound, 1.0f);

                }
            }
        }
        else 
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                if (playerController.AmmoCount2 > 0)
                {
                    Instantiate(bullet2, transform.position + offset , transform.rotation);
                    playerController.AmmoCount2--;
                    gunAudio.PlayOneShot(shotgunSound, 1.0f);
                }
                else 
                {
                    gunAudio.PlayOneShot(emptySound,1.0f);
                }
            }
        }
    }
}
