using System;
using UnityEngine;

namespace Raul
{
    public class CanvasManager : MonoBehaviour
    {
        public static event Action PulsadoNo;
        public static event Action PulsadoYes;
        [SerializeField] private Canvas canvasPregunta;

        void Start()
        {
            PlanetScript.ActivaCanvas += ActivaCanvas;
            PlanetScript.PlanetaActivo += IrAPlaneta;
        }

        private void ActivaCanvas()
        {
            canvasPregunta.gameObject.SetActive(true);
        }

        private void IrAPlaneta(GameObject planeta)
        {
            Debug.Log("SE HA SELECCIONADO EL PLANTA " + planeta.transform.parent.gameObject);
        }

        public void ButtonNo()
        {
            canvasPregunta.gameObject.SetActive(false);
            PulsadoNo?.Invoke();
        }

        public void ButtonYes()
        {
            canvasPregunta.gameObject.SetActive(false);
            PulsadoYes?.Invoke();
        }
    }
}
