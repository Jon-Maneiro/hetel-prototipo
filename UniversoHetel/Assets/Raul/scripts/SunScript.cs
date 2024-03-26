using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Rotate), 0f, 0.01f);
    }
    
    private void Rotate()
    {
        transform.Rotate(0, 0, 3*Time.deltaTime, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
