using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject loseScreen;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerController.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(playerController.isDead == true) 
       {
            Cursor.lockState = CursorLockMode.Confined;//Hides tHE CURSOR
            loseScreen.gameObject.SetActive(true);
            Debug.Log("Lose");
       }
    }


    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        playerController.isDead = true;
    }

    // i need to fix this button
}
