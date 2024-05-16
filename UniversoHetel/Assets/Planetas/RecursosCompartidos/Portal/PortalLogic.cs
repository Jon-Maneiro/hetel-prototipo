using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PortalLogic : MonoBehaviour
{

    public string targetScene = null;
    private GameObject nave;
    
    
    // Start is called before the first frame update
    void Start()
    {
        nave = GameObject.Find("fighter01(Clone)");
        
        //Tell the game what the current Screen is
        LoadingData.CurrentScene = SceneManager.GetActiveScene().name;
        
        //What minigame to load
        if (targetScene.Length == 0)
        {
            targetScene =
                LoadingData.AsteroidMinigameList[Random.Range(0, (LoadingData.AsteroidMinigameList.Length))];
        }

    }

    private void FixedUpdate()
    {
        transform.LookAt(nave.transform);
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
