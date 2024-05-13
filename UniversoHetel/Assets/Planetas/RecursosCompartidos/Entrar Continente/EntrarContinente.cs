using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EntrarContinente : MonoBehaviour
{
    
    //This script NEEDS to be in every continent object you want to be entered into.

    [SerializeField] private string[] minigameToGo;
    [SerializeField] private string continentToGo;
    [SerializeField] private GameObject canvasEntrarContinente;

    private bool _isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadingData.CurrentScene = "DigitalScene";
        LoadingData.NextContinent = continentToGo;

        EnterContButtonEvents.AcceptEnter += CanvasOutcome;
    }
    private void OnDestroy()
    {
        EnterContButtonEvents.AcceptEnter -= CanvasOutcome;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isActive = true;
            ActivateCanvas();
        }
    }

    
    
    private void ActivateCanvas()
    {
        Time.timeScale = 0;
        canvasEntrarContinente.SetActive(true);
        throw new NotImplementedException();
    }

    private void ChangeText()//Needed for different continent texts
    {
        
        //TODO Change text to continent specific text
        //TODO Change text to continent specific text
        //TODO Change text to continent specific text
        //TODO Change text to continent specific text
        //TODO Change text to continent specific text
        //TODO Change text to continent specific text
        throw new NotImplementedException();
    }

    private void CanvasOutcome(bool enter)
    {
        if (!_isActive) return;
        
        if (enter)
        {
            AceptEnter();
        }
        else
        {
            CancelEnter();
        }
    }

    public void AceptEnter()
    {
        Time.timeScale = 1;
        string selectedMinigame = minigameToGo[Random.Range(0, minigameToGo.Length - 1)];
        LoadingData.SceneToLoad = selectedMinigame;
        SceneManager.LoadScene("LoadingScreen");   
    }

    public void CancelEnter()
    {
        Time.timeScale = 1;
        canvasEntrarContinente.SetActive(false);
    }
    


}
