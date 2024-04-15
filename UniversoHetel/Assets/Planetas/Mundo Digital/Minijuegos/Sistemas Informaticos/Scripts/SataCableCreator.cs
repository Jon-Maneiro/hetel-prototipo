using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SataCableCreator : MonoBehaviour
{
    [SerializeField] private GameObject objectFrom;
    [SerializeField] private GameObject objectTo;
    [SerializeField] private LineRenderer lineRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 2;

        InvokeRepeating(nameof(DrawLine), 0f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Todo lo que fuera a ir en el Update va aqui
    private void DrawLine()
    {
        lineRenderer.SetPosition(0,objectFrom.transform.position);
        lineRenderer.SetPosition(1,objectTo.transform.position);
    }
}
