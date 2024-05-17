using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject canvasPausa;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                ActivarCanvas();
            }
            else
            {
                Continuar();
            }
            
        }
    }
    
    public void ActivarCanvas()
    {
        Time.timeScale = 0;
        canvasPausa.SetActive(true);
    }

    public void Customizacion()
    {
        Time.timeScale = 1;
        LoadingData.SceneToLoad = "CustomizationScene";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        LoadingData.SceneToLoad = "Menu";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        canvasPausa.SetActive(false);
    }
}
