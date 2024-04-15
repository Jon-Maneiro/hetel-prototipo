using System;
using UnityEngine;

namespace Raul.scripts
{
    public class PataScript : MonoBehaviour
    {
        public bool _activo;

        private void Start()
        {
            _activo = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("salida"))
            {
                _activo = true;
                GetComponent<ParticleSystem>().Play();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("salida"))
            {
                _activo = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("salida"))
            {
                _activo = true;
            }
        }

        public bool GetActivo()
        {
            return _activo;
        }
    }
}
