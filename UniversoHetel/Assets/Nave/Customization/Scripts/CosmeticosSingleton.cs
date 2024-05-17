using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticosSingleton : MonoBehaviour
{
    public static CosmeticosSingleton Instance { get; private set; }

    public bool[] gorros1;
    public bool[] gorros2;
    public bool[] gorros3;
    
    public bool gorros1ocupied;
    public bool gorros2ocupied;
    public bool gorros3ocupied;

    public bool[] stickers;
    
    public static event Action<bool> UpdateCosmetics;
    
    void Start()
    {
        //Comprobar si los espacios ya estan ocupados
        for (int j = 0; j < gorros1.Length; j++)
        {
            if (gorros1[j])
            {
                gorros1ocupied = true;
            }
        }
        
        for (int j = 0; j < gorros2.Length; j++)
        {
            if (gorros2[j])
            {
                gorros2ocupied = true;
            }
        }
        
        for (int j = 0; j < gorros3.Length; j++)
        {
            if (gorros3[j])
            {
                gorros3ocupied = true;
            }
        }
        UpdateCosmetics?.Invoke(true);
        
    }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        DontDestroyOnLoad(gameObject);
        
        UpdateCosmetics?.Invoke(true);
    }
    
    public void changeHat(int id)
    {
        bool quitar = false;
        
        //comprobar si el gorro seleccionado es el que esta puesto
        for (int j = 0; j < gorros1.Length; j++)
        {
            if (gorros1[j])
            {
                if (j == id)
                {
                    //Quitar el gorro seleccionado
                    gorros1[id] = false;
                    gorros1ocupied = false;
                    quitar = true;
                }
            }
        }
            
        for (int j = 0; j < gorros2.Length; j++)
        {
            if (gorros2[j])
            {
                if (j == id)
                {
                    //Quitar el gorro seleccionado
                    gorros2[id] = false;
                    gorros2ocupied = false;
                    quitar = true;
                }
            }
        }
            
        for (int j = 0; j < gorros3.Length; j++)
        {
            if (gorros3[j])
            {
                if (j == id)
                {
                    //Quitar el gorro seleccionado
                    gorros3[id] = false;
                    gorros3ocupied = false;
                    quitar = true;
                }
            }
        }

        //Poner gorro
        if (!quitar)
        {
            if (!gorros1ocupied)
            {
                if (gorros1.Length <= id)
                {
                    Debug.Log("El sombrero seleccionado no esiste");
                }
                else
                {
                    if (gorros1[id])
                    {
                        gorros1[id] = false;
                        gorros1ocupied = false;
                    }
                    else
                    {
                        gorros1[id] = true;
                        gorros1ocupied = true;
                    }
                }
            }
            else if (!gorros2ocupied)
            {
                if (gorros2.Length <= id)
                {
                    Debug.Log("El sombrero seleccionado no esiste");
                }
                else
                {
                    if (gorros2[id])
                    {
                        gorros2[id] = false;
                        gorros2ocupied = false;
                    }
                    else
                    {
                        gorros2[id] = true;
                        gorros2ocupied = true;
                    }
                }
            }
            else if (!gorros3ocupied)
            {
                if (gorros3.Length <= id)
                {
                    Debug.Log("El sombrero seleccionado no esiste");
                }
                else
                {
                    if (gorros3[id])
                    {
                        gorros3[id] = false;
                        gorros3ocupied = false;
                    }
                    else
                    {
                        gorros3[id] = true;
                        gorros3ocupied = true;
                    }
                }
            }
            else
            {
                Debug.Log("No hay espacio");
            }
        }

        UpdateCosmetics?.Invoke(true);
    }
    
    public void changesticker(int id)
    {
        if (stickers.Length <= id)
        {
            Debug.Log("El pegatina seleccionado no esiste");
        }
        else
        {
            if (stickers[id])
            {
                stickers[id] = false;
            }
            else
            {
                stickers[id] = true;
            }
        } 
        UpdateCosmetics?.Invoke(true);
    }
    
}
