using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject tutorialCanvas;

    public static event Action<bool> GameStop;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameCanvas.SetActive(false);
    }

    private void OnDestroy()
    {
        
    }

    public void ExitTutorial()
    {
        GameStop?.Invoke(false);
        tutorialCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1;
    }

}
