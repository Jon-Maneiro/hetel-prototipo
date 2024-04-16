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
        
    }


    private void OnTriggerEnter(Collider other)
    {
        LoadingData.sceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScreen");
    }
}
