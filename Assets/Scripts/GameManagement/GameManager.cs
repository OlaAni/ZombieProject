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
    public TextMeshProUGUI timerText;

    public PlayerController playerController;
    public float timer = 50;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerController.FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, -1, 30);

        timerText.text = "" + Mathf.Round(timer);

       if(playerController.isDead == true || timer <= 0) 
       {

            Cursor.lockState = CursorLockMode.Confined;
            playerController.isDead = true;
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
