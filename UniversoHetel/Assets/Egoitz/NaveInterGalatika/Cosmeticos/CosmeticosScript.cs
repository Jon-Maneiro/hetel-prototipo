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

    private void updateCosmetics()
    {

        for (int i = 0; i < stickers.Length; i++)
        {
            if (CosmeticosSingleton.Instance.stickers[i])
            {
                stickers[i].SetActive(true);
            }
            else
            {
                stickers[i].SetActive(false);
            }
        }
        
        for (int i = 0; i < gorros.Length; i++)
        {
            if (CosmeticosSingleton.Instance.gorros[i])
            {
                gorros[i].SetActive(true);
            }
            else
            {
                gorros[i].SetActive(false);
            }
        }
        
    }
}
