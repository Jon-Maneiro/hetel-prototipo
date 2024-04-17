using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoContinental : MonoBehaviour
{
    [SerializeField] private GameObject objectFollow;

    private Vector3 cameraPosition;

    private bool edgeScroll;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moverse con el teclado
        float moveAmount = 20f;
        if (Input.GetKey(KeyCode.W))
        {
            cameraPosition.z += moveAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraPosition.z -= moveAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraPosition.x -= moveAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraPosition.x += moveAmount * Time.deltaTime;
        }
        
        //Moverse con los bordes (EdgeScroll)
        float edgeSize = 40f;

        if (Input.GetKey(KeyCode.Space))
        {
            edgeScroll = !edgeScroll;
            Debug.Log("EdgeScroll: " + edgeScroll);
        }

        if (edgeScroll)
        {
            if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                cameraPosition.z += moveAmount * Time.deltaTime;
            }
            if (Input.mousePosition.y < Screen.height - edgeSize)
            {
                cameraPosition.z -= moveAmount * Time.deltaTime;
            }
        
        
            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                cameraPosition.x += moveAmount * Time.deltaTime;
            }
            if (Input.mousePosition.x < Screen.width - edgeSize)
            {
                cameraPosition.x -= moveAmount * Time.deltaTime;
            }
        }
        
        //Actualizar Posicion
        objectFollow.transform.position = cameraPosition;

    }
}
