using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject pic;

    [SerializeField] private GameObject pic2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Continuar();
            }
            else
            {
                pic2.SetActive(true);
                Time.timeScale = 0;
                
            }
        }
    }
    
    public void Continuar()
    {
        Time.timeScale = 1;
        pic2.SetActive(false);
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
