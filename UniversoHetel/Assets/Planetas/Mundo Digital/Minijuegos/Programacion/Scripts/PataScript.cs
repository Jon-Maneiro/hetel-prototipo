using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     *  Script del prefab "Pata"
     *  Detecta con los metodos "OnTrigger..." los objetos con el tag "salida"
     *  Cambia la variable "_activo" en caso de estar en contacto con uno de estos objetos
     */
    public class PataScript : MonoBehaviour
    {
        private bool _activo;

        private void Start()
        {
            _activo = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("salida")) return;
            _activo = true;
            GetComponent<ParticleSystem>().Play();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("salida")) return;
            _activo = false;
            GetComponent<ParticleSystem>().Stop();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("salida")) return;
            _activo = true;
        }

        public bool GetActivo()
        {
            return _activo;
        }
    }
}
