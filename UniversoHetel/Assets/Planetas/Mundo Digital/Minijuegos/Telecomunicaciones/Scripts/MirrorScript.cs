using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    private float[] rotations = { 0, 90, 45, -45};
    
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0,0,rotations[rand]); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateMirror()
    {
        transform.Rotate(new Vector3(0f,0f,-15f), Space.Self);
    }
}
