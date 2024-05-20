using System;
using System.Collections;
using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script del prefab "LedDiodeGreenPowered" (||)
     * Detecta si alguna o sus dos "Patas" están activas
     * En caso de que no tenga ninguna activa, desactiva la LED
     * Tiene la condición para ganar, si la LED esta activada durante 3 segundos, se gana la partida
     */
    public class LedScript : MonoBehaviour
    {
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject pata2Object;
        [SerializeField] private GameObject salida;
        [SerializeField] private GameObject modelo;
        [SerializeField] private bool and;
        [SerializeField] private GameObject CanvasWin;
        
        public static event Action WinGame;
        
        private bool _pata1, _pata2;
        private Renderer _renderer;
        
        void Start()
        {
            _renderer = modelo.GetComponent<Renderer>();
            
            PataScript.Activo += PataActivo;
            PataScript.Desactivo += PataDesactivo;
            
            CheckPatas();
        }
        
        private void PataActivo(GameObject pata)
        {
            if (pata.Equals(pata1Object))
            {
                _pata1 = true;
            }
            if (pata.Equals(pata2Object))
            {
                _pata2 = true;
            }
            CheckPatas();
        }
        
        private void PataDesactivo(GameObject pata)
        {
            if (pata.Equals(pata1Object))
            {
                _pata1 = false;
            }
            if (pata.Equals(pata2Object))
            {
                _pata2 = false;
            }
            CheckPatas();
        }

        private void CheckPatas()
        {
            var salidaPosition = salida.transform.position;
            var position = new Vector3(salidaPosition.x,salidaPosition.y, transform.position.z);
            if (and)
            {
                if (_pata1 && _pata2)
                {
                    MinijuegoProgGeneral.ActivarSalida(salida, position, _renderer, new []{0,1,2}, Color.yellow);
                    StartCoroutine(nameof(CheckGame));
                }
                else
                {
                    MinijuegoProgGeneral.DesactivarSalida(salida, position, _renderer, new []{0,1,2}, Color.gray);
                    StopCoroutine(nameof(CheckGame));
                }
            }
            else
            {
                if (_pata1 || _pata2)
                {
                    MinijuegoProgGeneral.ActivarSalida(salida, position, _renderer, new []{0,1,2}, Color.yellow);
                    StartCoroutine(nameof(CheckGame));
                }
                else
                {
                    MinijuegoProgGeneral.DesactivarSalida(salida, position, _renderer, new []{0,1,2}, Color.gray);
                    StopCoroutine(nameof(CheckGame));
                }
            }
            
        }

        private IEnumerator CheckGame()
        {
            yield return new WaitForSeconds(3f);
            if (_pata1 || _pata2)
            {
                CanvasWin.SetActive(true);
                yield return new WaitForSeconds(2f);
                WinGame?.Invoke();
            }
        }
    }
}
