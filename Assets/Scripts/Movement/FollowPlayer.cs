using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    Scene m_Scene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if(sceneName == "EasyScene") 
        {
            speed = 2;
        }
        else if(sceneName == "HardScene") 
        {
            speed = 4;
        }        
        else if(sceneName == "NightmareScene") 
        {
            speed = 1;
        }
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        //bug.Log(speed);
    }

   
}
