using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycastTube : MonoBehaviour
{

    private Camera _cam;
    private Vector3 mousePos;
    [SerializeField] private LayerMask mask;
    private bool activo;
    
    // Start is called before the first frame update
    void Start()
    {
        TubeGameControllerScript.Win += DescativarRayo;
        activo = true;
        _cam = Camera.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            LaunchRay();
        }
    }
    
    private void DescativarRayo()
    {
        activo = false;
    }

    private void LaunchRay()
    {
        //Draw Ray
        mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = _cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if(hit.transform.gameObject.GetComponent<TubeScript>() is not null)
                hit.transform.gameObject.GetComponent<TubeScript>().RotatePiece();
            }
        }
    }
}
