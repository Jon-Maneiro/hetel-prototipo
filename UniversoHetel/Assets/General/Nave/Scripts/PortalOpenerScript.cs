using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalOpenerScript : MonoBehaviour
{

    public InputActions _control;
    
    // Start is called before the first frame update
    void Start()
    {
        _control = new InputActions();
        _control.Enable();
        
        PlayerInput.OpenAstralMap += PlanetSelectionScene;
    }

    //If Ship gets destroyed, avoid NullPointerException
    private void OnDestroy()
    {
        PlayerInput.OpenAstralMap -= PlanetSelectionScene;
    }

    private void PlanetSelectionScene()
    {
        LoadingData.shipPosition = gameObject.transform.position;
        LoadingData.shipRotation = gameObject.transform.rotation;
        LoadingData.SceneToLoad = LoadingData.PlanetSelection;
        SceneManager.LoadScene("LoadingScreen");
    }
}
