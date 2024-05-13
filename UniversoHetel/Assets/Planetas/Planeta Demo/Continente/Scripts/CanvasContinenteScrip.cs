using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasContinenteScrip : MonoBehaviour
{
     private GameObject canvas1; //Canvas del Lugar
     private GameObject canvas2; //Canvas del Persona
     private GameObject canvas3; //Canvas del Mision
    
    void Start()
    {
        //Suscribirse al evento de ser activado
        Raycastcosa.ActivaCanvasContinente += OnActivaCanvasContinente;
        
        canvas1 = GameObject.Find("CanvasEdificio");
        canvas2 = GameObject.Find("CanvasPersona");
        canvas3 = GameObject.Find("CanvasMision");
        
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        
        
        
    }

    private void OnActivaCanvasContinente(int tipo)
    {
        switch (tipo)
        {
            case 1:
                canvas1.gameObject.SetActive(true); 
                canvas2.gameObject.SetActive(false);
                canvas3.gameObject.SetActive(false);
                break;
            
            case 2:
                canvas1.gameObject.SetActive(false); 
                canvas2.gameObject.SetActive(true);
                canvas3.gameObject.SetActive(false);
                break;
            
            case 3:
                canvas1.gameObject.SetActive(false); 
                canvas2.gameObject.SetActive(false);
                canvas3.gameObject.SetActive(true);
                break;
        }
    }
}
