using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenLogic : MonoBehaviour
{
    /*To Use-----
     
     1.-Create script in scene where another scene has to be loaded.
            [SerializeField] private string targetScene;
            LoadingData.sceneToLoad = targetScene;
            SceneManager.LoadScene("LoadingScreen");
    
     2.- Have that method activated when you need to load scene.
     
     3.- It Should Work
     
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
        AsyncOperation operation = SceneManager.LoadSceneAsync(LoadingData.sceneToLoad);
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
}