using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasContinenteScrip : MonoBehaviour
{
    [SerializeField] private Canvas canvas1;
    [SerializeField] private Canvas canvas2;
    [SerializeField] private Canvas canvas3;
    
    // Start is called before the first frame update
    void Start()
    {
        Raycastcosa.ActivaCanvasContinente += OnActivaCanvasContinente;
    }

    // Update is called once per frame
    void Update()
    {
        
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
