using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public void VolverEmpezar()
    {
        Time.timeScale = 1;
        LoadingData.SceneToLoad = "EarthScene";
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
}
