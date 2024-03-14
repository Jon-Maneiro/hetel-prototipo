using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticosScript : MonoBehaviour
{
    
    [SerializeField] GameObject[] gorros;


    [SerializeField] GameObject[] stickers;
    


    
    // Start is called before the first frame update
    void Start()
    {
        updateCosmetics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateCosmetics()
    {

        for (int i = 0; i < stickers.Length; i++)
        {
            stickers[i].SetActive(CosmeticosSingleton.Instance.stickers[i]);
        }

        
        for (int j = 0; j < gorros.Length; j++)
        { 
            gorros[j].SetActive(CosmeticosSingleton.Instance.gorros[j]);
           
        }
        
    }
}
