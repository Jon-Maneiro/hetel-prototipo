using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatePiece()
    {
        transform.Rotate(new Vector3(0f,0f,-90f), Space.Self);
        Debug.Log("Rotando");
    }
}
