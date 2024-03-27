using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Invoke(nameof(StopTime), 0.5f);
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
            Invoke(nameof(StopTime), 0.5f);
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }
}
