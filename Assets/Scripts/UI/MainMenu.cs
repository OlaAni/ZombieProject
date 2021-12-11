using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneIndex = "EasyScene";
    public string sceneIndex2 = "HardScene";
    public string sceneIndex3 = "NightmareScene";
    public string sceneIndex4 = "MainMenu";
    // Start is called before the first frame update
    public void PlayEasyGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayHardGame()
    {
        SceneManager.LoadScene(sceneIndex2);
    }

    public void PlayNightmareGame()
    {
        SceneManager.LoadScene(sceneIndex3);
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadScene(sceneIndex4);
    }
}
