using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsScript : MonoBehaviour
{
    
    [SerializeField] GameObject[] gorros1;
    [SerializeField] GameObject[] gorros2;
    [SerializeField] GameObject[] gorros3;


    [SerializeField] GameObject[] stickers;

    
    // Start is called before the first frame update
    void Start()
    {
        CosmeticosSingleton.UpdateCosmetics += updateCosmetics;
        updateCosmetics(true);
    }
    
    void Awake()
    {
        CosmeticosSingleton.UpdateCosmetics += updateCosmetics;
        updateCosmetics(true);
    }

    private void OnDestroy()
    {
        CosmeticosSingleton.UpdateCosmetics -= updateCosmetics;
    }
    
    public void updateCosmetics(bool booleano)
    {
        Debug.Log("Updating!");
        
        for (int i = 0; i < stickers.Length; i++)
        {
            Debug.Log(stickers[i].gameObject.ToString());
            //Debug.Log(CosmeticosSingleton.instance.stickers[i].ToString());
            stickers[i].SetActive(CosmeticosSingleton.instance.stickers[i]);
        }
        
        for (int j = 0; j < gorros1.Length; j++)
        { 
            Debug.Log(gorros1[j].gameObject.ToString());
            gorros1[j].SetActive(CosmeticosSingleton.instance.gorros1[j]);
        }
        
        for (int j = 0; j < gorros2.Length; j++)
        { 
            gorros2[j].SetActive(CosmeticosSingleton.instance.gorros2[j]);
           
        }
        
        for (int j = 0; j < gorros3.Length; j++)
        { 
            gorros3[j].SetActive(CosmeticosSingleton.instance.gorros3[j]);
           
        }
    }
}
