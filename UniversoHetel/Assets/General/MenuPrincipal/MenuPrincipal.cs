using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverEmpezar()
    {
        LoadingData.SceneToLoad = "SeleccionPlanetas";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Customizacion()
    {
        LoadingData.SceneToLoad = "CustomizationScene";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Idiomas()
    {
        LoadingData.SceneToLoad = "MinijuegoLaser 1";
        SceneManager.LoadScene("LoadingScreen");
    }
}
