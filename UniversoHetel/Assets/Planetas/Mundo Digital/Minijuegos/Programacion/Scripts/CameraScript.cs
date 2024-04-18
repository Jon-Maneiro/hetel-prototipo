using System;
using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script de la camara
     * Cuando se hace click lanza un raycast en la posición del ratón
     * En caso de chocar con un objeto del layer "Boton" lanza el evento "RayHit"
     * TODO: quitar el update y utilizar el sistema de InputAction
     */
    public class CameraScript : MonoBehaviour
    {
        public static event Action<GameObject> RayHit;
        [SerializeField] private LayerMask mask;
        private Camera _cam;
        
        void Start()
        {
            _cam = GetComponent<Camera>();
        }
        
        void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            var ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                RayHit?.Invoke(hit.transform.gameObject);
            }
        }
    }
}
