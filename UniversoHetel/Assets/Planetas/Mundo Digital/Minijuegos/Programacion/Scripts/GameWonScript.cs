using System;
using System.Collections;
using System.Collections.Generic;
using Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LedScript.WinGame += Success;
    }

    private void OnDestroy()
    {
        LedScript.WinGame -= Success;
    }

    private void Success()
    {
        LoadingData.SceneToLoad = LoadingData.NextContinent;
        SceneManager.LoadScene("LoadingScreen");
    }

}
