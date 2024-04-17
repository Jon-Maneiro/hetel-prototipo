using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasContinenteScrip : MonoBehaviour
{
    [SerializeField] private Canvas canvas1; //Canvas del Lugar
    [SerializeField] private Canvas canvas2; //Canvas del Persona
    [SerializeField] private Canvas canvas3; //Canvas del Mision
    
    void Start()
    {
        //Suscribirse al evento de ser activado
        Raycastcosa.ActivaCanvasContinente += OnActivaCanvasContinente;
    }

    private void OnActivaCanvasContinente(int tipo)
    {
        switch (tipo)
        {
            case 0:
                canvas1.gameObject.SetActive(true); 
                break;
            
            case 1:
                canvas2.gameObject.SetActive(true);
                break;
            
            case 2:
                canvas3.gameObject.SetActive(true);
                break;
        }
    }
}
