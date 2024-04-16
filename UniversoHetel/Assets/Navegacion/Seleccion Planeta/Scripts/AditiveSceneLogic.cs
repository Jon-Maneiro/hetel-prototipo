using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AditiveSceneLogic : MonoBehaviour
{
    private Scene _sceneToPause;
    // Start is called before the first frame update
    void Start()
    {
        _sceneToPause = SceneManager.GetSceneByName(LoadingData.currentScreen);
        SceneManager.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
