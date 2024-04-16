using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    public class PataScript : MonoBehaviour
    {
        public bool activo;

        private void Start()
        {
            activo = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("salida"))
            {
                activo = true;
                GetComponent<ParticleSystem>().Play();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("salida"))
            {
                activo = false;
                GetComponent<ParticleSystem>().Stop();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("salida"))
            {
                activo = true;
            }
        }

        public bool GetActivo()
        {
            return activo;
        }
    }
}
