using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script del prefab "OR" (||)
     * Detecta si alguna de sus dos "Patas" están activas
     * En caso de que alguna o ambas estén activas, activa la salida
     * En caso de que no tenga ninguna activa, desactiva la salida
     * TODO: Cambiar la comprobación de un "InvokeRepeating" a eventos
     */
    public class OrScript : MonoBehaviour
    {
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject pata2Object;
        [SerializeField] private GameObject salida;
        [SerializeField] private GameObject modelo;
        
        private PataScript _pata1, _pata2;
        private Renderer _renderer;
        
        void Start()
        {
            _pata1 = pata1Object.GetComponent<PataScript>();
            _pata2 = pata2Object.GetComponent<PataScript>();
            _renderer = modelo.GetComponent<Renderer>();
            InvokeRepeating(nameof(CheckPatas), 0f, 0.1f);
        }

        private void CheckPatas()
        {
            var position = salida.transform.position;
            if (_pata1.GetActivo() || _pata2.GetActivo())
            {
                MinijuegoProgGeneral.ActivarSalida(salida, position, _renderer, new []{1});
            }
            else
            {
                MinijuegoProgGeneral.DesactivarSalida(salida, position, _renderer, new []{1});
            }
        }
    }
}
