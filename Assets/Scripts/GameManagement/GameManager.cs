using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public GameObject pauseScreen;

    [Header("Game Logic")]
    public PlayerController playerController;
    public float timer = 30;
    public int score = 0;
    public bool paused = true;

    [Header("Scenes")]
    public string[] levelNames;

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
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;



        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 30);

        timerText.text = "" + Mathf.Round(timer);
        scoreText.text = "Score: " + score;

       if(playerController.isDead == true || timer <= 0) 
       {

            Cursor.lockState = CursorLockMode.Confined;
            playerController.isDead = true;
            SceneManager.LoadScene(levelNames[0]);

       }

        if (sceneName == "EasyScene")
        {
            if (score >= 10)
            {

                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(levelNames[1]);
            }
        }
        else if(sceneName == "HardScene") 
        {
            if (score >= 30)
            {

                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(levelNames[1]);
            }
        }


        Pause();
    }


    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
        playerController.isDead = true;
    }    
    
    public void Menu()
    {
        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelNames[2]);
    }


    public void Pause() //sets timer to 0
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && paused) 
        {
            pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            paused = false;
            Time.timeScale = 0f;
            Debug.Log("Pause");


        }
        else if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !paused)
        {
            pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            paused = true;
            Time.timeScale = 1f;
            Debug.Log("UnPause");

        }
    }
}
