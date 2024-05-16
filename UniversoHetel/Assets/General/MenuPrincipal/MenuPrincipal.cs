using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject pic;
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

    public void Idiomas()
    {
        if (pic.activeInHierarchy == false)
        {
            pic.SetActive(true);
        }
        else
        {
            pic.SetActive(false);
        }
    }
}
