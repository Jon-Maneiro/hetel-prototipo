using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static event Action<GameObject> RayHit;
    [SerializeField] private LayerMask mask;
    private Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                Debug.Log(hit.transform.gameObject.name);
                RayHit?.Invoke(hit.transform.gameObject);
            }
        }
    }
}
