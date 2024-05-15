using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirContinente : MonoBehaviour
{
    [SerializeField] private string planetSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        LoadingData.NextContinent = null;
        LoadingData.SceneToLoad = planetSceneName;
        SceneManager.LoadScene("LoadingScreen");
    }
}
