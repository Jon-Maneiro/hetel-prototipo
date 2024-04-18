using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AditiveSceneLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadingData.PlanetSelection));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(LoadingData.CurrentScene));
        */

        LoadingData.SceneToLoad = LoadingData.CurrentScene;//Return to the last scene when selecting
    }
}
