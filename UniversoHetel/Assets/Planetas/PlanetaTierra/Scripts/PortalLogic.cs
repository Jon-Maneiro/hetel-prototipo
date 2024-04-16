using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLogic : MonoBehaviour
{

    public string targetScene;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Tell the game what the current Screen is
        LoadingData.currentScreen = SceneManager.GetActiveScene().name;
    }


    private void OnTriggerEnter(Collider other)
    {
        LoadingData.sceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScreen");
    }
}
