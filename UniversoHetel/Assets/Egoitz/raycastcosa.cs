using System;
using System.Collections;
using System.Collections.Generic;
using Raul;
using UnityEngine;

public class Raycastcosa : MonoBehaviour
{
    public bool tipo;
    private bool _seleccionado;
    
    public static event Action<bool> ActivaCanvasContinente;
    //public static event Action ActivaCanvasContinente;
    
    // Start is called before the first frame update
    void Start()
    {
        PointScript.RayHit += RayHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void RayHit(GameObject hitObject)
    {
        if (!hitObject.Equals(gameObject)) return;
        ActivaCanvasContinente?.Invoke(tipo);
    }
}
