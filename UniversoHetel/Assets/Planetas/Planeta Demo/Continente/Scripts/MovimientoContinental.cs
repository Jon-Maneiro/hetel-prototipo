using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoContinental : MonoBehaviour
{
    void FixedUpdate()
    {
        
        float moveAmount = 10f;
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * moveAmount);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(-transform.forward * moveAmount);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(-transform.right * moveAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(transform.right * moveAmount);
        }
    }
}
