using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaserScoreScript : MonoBehaviour
{

    private int _goodPoints = 0;
    private int _badPoints = 0;
    [SerializeField] private int _vida = 0;
    [SerializeField] private Text _textoVida;
    [SerializeField] private Text _textoResultado;
    
    // Start is called before the first frame update
    void Start()
    {
        GoodCubeScript.SumarPunto += Add;
        BadCubeScript.RestarPunto += Substract;
        _textoVida.text = "Vida: " + _vida;
        _textoResultado.text = "";
    }

    private void Add()
    {
        _vida++;
        _goodPoints++;
        _textoResultado.text = "Succes!";
        //Invoke(nameof(StopTime), 0.5f);
        string nombreEscena = SceneManager.GetActiveScene().name;
        switch (nombreEscena)
        {
            case "MinijuegoLaser":
                LoadingData.SceneToLoad = "MinijuegoLaser 1";
                SceneManager.LoadScene("LoadingScreen");
                break;
            case "MinijuegoLaser 1":
                LoadingData.SceneToLoad = "MinijuegoLaser 2";
                SceneManager.LoadScene("LoadingScreen");
                break;
            case "MinijuegoLaser 2":
                LoadingData.SceneToLoad = "MinijuegoLaser 3";
                SceneManager.LoadScene("LoadingScreen");
                break;
            case "MinijuegoLaser 3":
                LoadingData.SceneToLoad = "MinijuegoLaser 4";
                SceneManager.LoadScene("LoadingScreen");
                break;
            case "MinijuegoLaser 4":
                LoadingData.SceneToLoad = "SeleccionPlanetas";
                SceneManager.LoadScene("LoadingScreen");
                break;
            default:
                break;
            
        }
        
        
    }

    private void Substract()
    {
        _vida--;
        _textoVida.text = "Vida: " + _vida;
        _badPoints++;

        if (_vida <= 0)
        {
            _textoResultado.text = "Failure!";
            _textoVida.text = "Vida: " + 0;
            LoadingData.SceneToLoad = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("LoadingScreen");
            //Invoke(nameof(StopTime), 0.5f);
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }
}
