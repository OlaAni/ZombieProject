using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSpeed = 200f;
    public Transform playerGameObject;
    public float LookUp = 0f;

    [Header("Gun Settings")]
    private float timeDelay = 1.0f;
    private float timer;
    public GameObject bullet;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Hides tHE CURSOR


        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

          if (Input.GetKeyDown(KeyCode.Space))
          {
             ShootBullet();
          }
   

        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;


        LookUp -= mouseY;

        LookUp = Mathf.Clamp(LookUp, -90f, 90f);//stops the camera from rotating to far up or down

        transform.localRotation = Quaternion.Euler(LookUp, 0f, 0f);//rotates around x axis
        playerGameObject.Rotate(Vector3.up * mouseX);//rotates around the y axis


    }


    public void ShootBullet() 
    {
        if (playerController.AmmoCount > 0)
        {
                Instantiate(bullet, transform.position, transform.rotation);
                playerController.AmmoCount--;
        }
    }
}
