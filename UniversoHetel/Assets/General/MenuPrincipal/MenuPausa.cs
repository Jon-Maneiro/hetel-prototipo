using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Continuar();
            }
        }
    }
    
    public void Continuar()
    {
        Time.timeScale = 1;
        transform.gameObject.SetActive(false);
    }

    public void Customizacion()
    {
        LoadingData.SceneToLoad = "CustomizationScene";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void MenuPrincipal()
    {
        LoadingData.SceneToLoad = "Menu Principal";
        SceneManager.LoadScene("LoadingScreen");
    }
}
