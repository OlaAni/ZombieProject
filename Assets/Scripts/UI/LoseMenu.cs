using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public string sceneIndex = "TestScene";
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Update is called once per frame

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
