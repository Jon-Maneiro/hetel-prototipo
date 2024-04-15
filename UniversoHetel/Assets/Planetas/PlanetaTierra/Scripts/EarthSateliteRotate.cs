using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSateliteRotate : MonoBehaviour
{

    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject moon;
    [SerializeField] private GameObject[] satelites;


    public float planetRotateSpeed = 20f;
    public float orbitSpeed = 10f;

    private Vector3 _arriba = new Vector3(0, 0, 1);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        earth.transform.Rotate( _arriba * planetRotateSpeed * Time.deltaTime);
        
        moon.transform.RotateAround(Vector3.zero, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
