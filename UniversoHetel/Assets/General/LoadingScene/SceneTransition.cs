using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadignScene()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void LoadScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
