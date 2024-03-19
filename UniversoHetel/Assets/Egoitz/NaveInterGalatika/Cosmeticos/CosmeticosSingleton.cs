using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticosSingleton : MonoBehaviour
{
    public static CosmeticosSingleton Instance { get; private set; }

    public bool[] gorros;

    public bool[] stickers;
    
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
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHat(int id)
    {
        if (gorros.Length <= id)
        {
            Debug.Log("El sombrero seleccionado no esiste");
        }
        else
        {
            if (gorros[id])
            {
                gorros[id] = false;
            }
            else
            {
                gorros[id] = true;
            }
        }    
            
        
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
       
    }
}
