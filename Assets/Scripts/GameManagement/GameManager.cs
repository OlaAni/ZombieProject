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
    public GameObject winScreen;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public GameObject pauseScreen;

    public PlayerController playerController;
    public float timer = 30;
    public int score = 0;
    public bool paused = true;


    Scene m_Scene;
    string sceneName; 

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerController.FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 30);

        timerText.text = "" + Mathf.Round(timer);
        scoreText.text = "Score: " + score;

       if(playerController.isDead == true || timer <= 0) 
       {

            Cursor.lockState = CursorLockMode.Confined;
            playerController.isDead = true;
            loseScreen.gameObject.SetActive(true);
       }

        if (score >= 20)
        {

            Cursor.lockState = CursorLockMode.Confined;
            winScreen.gameObject.SetActive(true);
            Debug.Log("Win");
        }


        Pause();
    }


    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        playerController.isDead = true;
    }


    public void Pause() 
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && paused) 
        {
            pauseScreen.SetActive(true);
            paused = false;
            Time.timeScale = 0f;
            Debug.Log("Pause");

        }
        else if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !paused)
        {
            pauseScreen.SetActive(false);
            paused = true;
            Time.timeScale = 1f;
            Debug.Log("UnPause");

        }
    }
}
