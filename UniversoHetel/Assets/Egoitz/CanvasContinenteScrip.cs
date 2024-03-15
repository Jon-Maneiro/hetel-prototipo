using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasContinenteScrip : MonoBehaviour
{
    [SerializeField] private Canvas canvas1;
    [SerializeField] private Canvas canvas2;
    
    // Start is called before the first frame update
    void Start()
    {
        Raycastcosa.ActivaCanvasContinente += OnActivaCanvasContinente;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnActivaCanvasContinente(bool tipo)
    {
        if (tipo)
        {
            canvas1.gameObject.SetActive(true);
        }
        else
        {
            canvas2.gameObject.SetActive(true);
        }
        
        
    }
}
