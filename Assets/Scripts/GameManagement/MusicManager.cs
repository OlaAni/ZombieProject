using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    Scene m_Scene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if (sceneName == "EasyScene")
        {
            audioSource.clip = audioClip[1];
            audioSource.Play();
        }
        else if (sceneName == "HardScene")
        {
            audioSource.clip = audioClip[2];
            audioSource.Play();
        }        
        else if (sceneName == "NightmareScene")
        {
            audioSource.clip = audioClip[3];
            audioSource.Play();
        }

        audioSource.loop = true;
    }
}
