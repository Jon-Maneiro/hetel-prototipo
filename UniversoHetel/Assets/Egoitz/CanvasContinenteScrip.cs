using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasContinenteScrip : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        Raycastcosa.ActivaCanvasContinente += OnActivaCanvasContinente;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnActivaCanvasContinente()
    {
        canvas.gameObject.SetActive(true);
    }
}
