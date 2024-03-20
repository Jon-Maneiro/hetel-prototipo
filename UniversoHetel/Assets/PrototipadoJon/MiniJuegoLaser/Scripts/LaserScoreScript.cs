using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScoreScript : MonoBehaviour
{

    private int _goodPoints = 0;
    private int _badPoints = 0;
    private int _total = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GoodCubeScript.SumarPunto += Add;
        BadCubeScript.RestarPunto += Substract;
    }

    private void Add()
    {
        _total++;
        _goodPoints++;
    }

    private void Substract()
    {
        _total--;
        _badPoints++;
    }
}
