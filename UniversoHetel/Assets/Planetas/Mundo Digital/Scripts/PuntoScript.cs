using System;
using System.Collections;
using UnityEngine;

namespace Planetas.Mundo_Digital.Scripts
{
    public class PuntoScript : MonoBehaviour
    {
        public static Action<GameObject> OtroPunto;
        public static Action<Vector3> DecirPuntos;
        
        void Start()
        {
            StartCoroutine(nameof(MandarPunto));
        }

        private IEnumerator MandarPunto()
        {
            yield return new WaitForSeconds(1f);
            DecirPuntos?.Invoke(transform.position);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Robot"))
            {
                OtroPunto?.Invoke(other.gameObject);
            }
        }
        
        /*private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Robot"))
            {
                OtroPunto?.Invoke(other.gameObject);
            }
        }*/
    }
}
