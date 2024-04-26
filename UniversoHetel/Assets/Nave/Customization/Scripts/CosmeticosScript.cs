using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticosScript : MonoBehaviour
{
    
    [SerializeField] GameObject[] gorros1;
    [SerializeField] GameObject[] gorros2;
    [SerializeField] GameObject[] gorros3;


    [SerializeField] GameObject[] stickers;
    


    
    // Start is called before the first frame update
    void Start()
    {
        CosmeticosSingleton.UpdateCosmetics += updateCosmetics;
    }
    

    private void OnDestroy()
    {
        CosmeticosSingleton.UpdateCosmetics -= updateCosmetics;
    }
    
    public void updateCosmetics(bool booleano)
    {

        for (int i = 0; i < stickers.Length; i++)
        {
            stickers[i].SetActive(CosmeticosSingleton.Instance.stickers[i]);
        }

        
        for (int j = 0; j < gorros1.Length; j++)
        { 
            gorros1[j].SetActive(CosmeticosSingleton.Instance.gorros1[j]);
           
        }
        
        for (int j = 0; j < gorros2.Length; j++)
        { 
            gorros2[j].SetActive(CosmeticosSingleton.Instance.gorros2[j]);
           
        }
        
        for (int j = 0; j < gorros3.Length; j++)
        { 
            gorros3[j].SetActive(CosmeticosSingleton.Instance.gorros3[j]);
           
        }
        
    }
}
