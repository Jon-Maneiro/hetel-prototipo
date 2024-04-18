using System;
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
        public static event Action<GameObject> Activo;
        public static event Action<GameObject> Desactivo;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("salida")) return;
            Activo?.Invoke(gameObject);
            GetComponent<ParticleSystem>().Play();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("salida")) return;
            Desactivo?.Invoke(gameObject);
            GetComponent<ParticleSystem>().Stop();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("salida")) return;
            Activo?.Invoke(gameObject);
        }
    }
}
