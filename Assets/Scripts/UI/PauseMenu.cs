using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pausedGame = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (pausedGame) 
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume() 
    {
        Time.timeScale = 1f;
        pausedGame = false;
    }    
    
    public void Pause() 
    {
        Time.timeScale = 0f;
        pausedGame = true;
    }
}
