using System;
using System.Collections;
using System.Collections.Generic;
using Raul;
using UnityEngine;

public class Raycastcosa : MonoBehaviour
{
    //[SerializeField] private GameObject canvas;
    public int tipo; //1=lugar, 2=persona, 3=mision
    private bool _seleccionado;

    
    //Crear evento de activar canvas
    public static event Action<int> ActivaCanvasContinente;

    void Start()
    {
        //Suscribirse al evento de ser clickado
        PointScript.RayHit += RayHit;
    }
    
    private void RayHit(GameObject hitObject) //Cuando es recive el evento de ser clickado lanzar el evento de activar canvas
    {
        if (!hitObject.Equals(gameObject)) return;
        ActivaCanvasContinente?.Invoke(tipo);
        //canvas.gameObject.SetActive(true); 
    }
}
