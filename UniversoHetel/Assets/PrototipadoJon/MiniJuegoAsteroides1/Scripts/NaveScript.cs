using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && (transform.position.x > -7) )
        {
            transform.position = new Vector3(transform.position.x - 0.05f,
                transform.position.y,
                transform.position.z); 
        }

        if (Input.GetKey(KeyCode.D) && (transform.position.x))
        {
            transform.position = new Vector3(transform.position.x + 0.05f, 
                transform.position.y,
                transform.position.z);
        }
    }
}
