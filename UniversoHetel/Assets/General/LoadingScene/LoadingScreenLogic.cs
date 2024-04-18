using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenLogic : MonoBehaviour
{
    /*
     
     ----- How To Use -----
     
     1.-Create script in scene where another scene has to be loaded(i.e. a scene with a portal).
            
            --The variable to know what scene is next
            public string targetScene;
            
            --on Start, if Scene is a Planet Scene (Not a Minigame or Continent)
            LoadingData.currentScene = SceneManager.GetActiveScene().name ( Or the name of the current Scene )
            
            --The two lines bellow go in another method
            
            LoadingData.sceneToLoad = targetScene;
            SceneManager.LoadScene("LoadingScreen");
    
     2.- Have that method activated when you need to load scene.
     
     3.- The code will launch the Loading Screen and change to the target Scene when fully loaded.
     
     ----- More Info -----
     
     For more complex Scene transition logic, see LoadingData.cs, there are variables usable to store scenes and
     code more complex logics. Please, use this or more variables to transition between scenes, and keep them 
     in the LoadingData.cs Script.
     
     */
    [SerializeField] private Image _progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        //Create async operation to load next scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(LoadingData.SceneToLoad);
        //Stop the next scene from activating
        operation.allowSceneActivation = false;
        
        while (!operation.isDone)
        {
            _progressBar.fillAmount = Mathf.Clamp01(operation.progress / .9f);
            if (operation.progress >= 0.9f)
            {
                //When loaded, allow to activate;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    
    private void showLoadingTips()
    {
        throw new NotImplementedException();
    }

    private void changeLoadingBackgroundImage()
    {
        throw new NotImplementedException();
    }
}
