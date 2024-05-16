using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsDestroyExplode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("laser"))
        {
            TriggerDestroyMeteor();
        }
    }


    private void TriggerDestroyMeteor()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Invoke(nameof(DeleteSelf),2f);
    }

    private void DeleteSelf()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
