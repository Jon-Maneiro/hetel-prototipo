using System;
using UnityEngine;
using UnityEngine.UI;

namespace Raul
{
    public class CanvasManager : MonoBehaviour
    {
        
        [SerializeField] private Canvas canvasPregunta;
        [SerializeField] private Button boton1;
        [SerializeField] private Button boton2;
        void Start()
        {
            PlanetScript.ActivaCanvas += ActivaCanvas;
        }

        private void ActivaCanvas()
        {
            canvasPregunta.gameObject.SetActive(true);
            /*boton1.transform.gameObject.SetActive(true);
            boton2.transform.gameObject.SetActive(true);*/
        }
    }
}
