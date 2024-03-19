using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Raul
{
    public class PointScript : MonoBehaviour
    {
        public static event Action<GameObject> RayHit;
        [SerializeField] private LayerMask mask;
        
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Camera cam = GetComponent<Camera>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, mask))
                {
                    RayHit?.Invoke(hit.transform.gameObject);
                }
            }
        }
    }
}
