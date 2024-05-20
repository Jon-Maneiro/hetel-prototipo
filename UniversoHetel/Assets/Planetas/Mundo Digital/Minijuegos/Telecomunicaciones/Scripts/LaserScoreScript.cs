using System;
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
    [SerializeField] private GameObject canvasWin;
    [SerializeField] private GameObject canvasLose;
    
    // Start is called before the first frame update
    void Start()
    {
        GoodCubeScript.SumarPunto += Add;
        BadCubeScript.RestarPunto += Substract;
        _textoVida.text = "" + _vida;
    }

    private void OnDestroy()
    {
        GoodCubeScript.SumarPunto -= Add;
        BadCubeScript.RestarPunto -= Substract;
    }

    private void Add()
    {
        _vida++;
        _goodPoints++;
        canvasWin.SetActive(true);
        
        Invoke(nameof(Success),2f);

    }

    private void Substract()
    {
        _vida--;
        _textoVida.text = "" + _vida;
        _badPoints++;

        if (_vida <= 0)
        {
            canvasLose.SetActive(true);
            _textoVida.text = "" + 0;
            Invoke(nameof(Failure), 2f);
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }


    private void Failure()
    {
        LoadingData.SceneToLoad = LoadingData.CurrentScene;
        SceneManager.LoadScene("LoadingScreen");
    }

    private void Success()
    {
        LoadingData.SceneToLoad = LoadingData.NextContinent;
        SceneManager.LoadScene("LoadingScreen");
    }



}
