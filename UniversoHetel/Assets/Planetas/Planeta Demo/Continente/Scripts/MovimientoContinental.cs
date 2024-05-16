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
        float moveAmount = 10f;
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * moveAmount);
            //GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x,transform.position.y, transform.position.z + moveAmount));
            //cameraPosition = Vector3.Lerp(cameraPosition,
              //  new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 1), moveAmount);
            //cameraPosition.z += moveAmount * Time.deltaTime;
            //cameraPosition = Vector3.MoveTowards(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 1), moveAmount);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //cameraPosition.z -= moveAmount * Time.deltaTime;
            //cameraPosition = Vector3.MoveTowards(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z -1), moveAmount);
            GetComponent<Rigidbody>().AddForce(-transform.forward * moveAmount);
            //GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x,transform.position.y, transform.position.z - moveAmount));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //cameraPosition.x -= moveAmount * Time.deltaTime;
            //cameraPosition = Vector3.MoveTowards(cameraPosition, new Vector3(cameraPosition.x - 1, cameraPosition.y, cameraPosition.z), moveAmount);
            //GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x - moveAmount, transform.position.y, transform.position.z));
            GetComponent<Rigidbody>().AddForce(-transform.right * moveAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //cameraPosition.x += moveAmount * Time.deltaTime;
            //cameraPosition = Vector3.MoveTowards(cameraPosition, new Vector3(cameraPosition.x + 1, cameraPosition.y, cameraPosition.z), moveAmount);
            //GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x + moveAmount, transform.position.y, transform.position.z));
            GetComponent<Rigidbody>().AddForce(transform.right * moveAmount);
        }
        
        /*//Moverse con los bordes (EdgeScroll)
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
        }*/
        
        //Actualizar Posicion
        //objectFollow.transform.position = cameraPosition;

    }
}
