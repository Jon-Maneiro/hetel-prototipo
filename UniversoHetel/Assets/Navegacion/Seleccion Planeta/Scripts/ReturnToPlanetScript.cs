using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPlanetScript : MonoBehaviour
{
    public void ReturnToOrbit()
    {
        LoadingData.SceneToLoad = LoadingData.CurrentScene;
        SceneManager.LoadScene("LoadingScreen");
    }
}
