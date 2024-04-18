using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PortalLogic : MonoBehaviour
{

    public string targetScene = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Tell the game what the current Screen is
        LoadingData.CurrentScene = SceneManager.GetActiveScene().name;
        
        //What minigame to load
        if (targetScene.Equals(null))
        {
            targetScene =
                LoadingData.AsteroidMinigameList[Random.Range(0, (LoadingData.AsteroidMinigameList.Length - 1))];
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadingData.SceneToLoad = targetScene;
            SceneManager.LoadScene("LoadingScreen");    
        }
    }
}
