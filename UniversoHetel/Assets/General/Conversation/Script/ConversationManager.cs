using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{

    [SerializeField] private String[] conversation;
    [SerializeField] private Text text;
    private int current =0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }
    
    public void Back()
    {
        if ((current-1) >= 0)
        {
            current--;
            text.text = conversation[current];
        }
    }
    
    public void Next()
    {
        if ((current+1) < conversation.Length)
        {
            current++;
            text.text = conversation[current];
        }
    }
    
    public void Restart()
    {
        current = 0;
        text.text = conversation[current];
    }
}

//Industria Manufacturera: En empresas que producen una amplia gama de productos, como automóviles, productos electrónicos, productos químicos, alimentos, entre otros.

//Especialista en Automatización Industrial: Diseña y desarrolla sistemas de automatización industrial, lidera proyectos y garantiza la eficiencia operativa.

//Hola! Somos del grado de eolica para reparar este aereogenerador necestitamos que nos traigas una tuerca del 15.8º puedes encontrarla en el planeta ingenieria.