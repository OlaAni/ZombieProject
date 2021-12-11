using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public string sceneIndex = "EasyScene";
    public string sceneIndex2 = "EasyScene";
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene(sceneIndex2);
    }

    // Update is called once per frame

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
