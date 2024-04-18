using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script del prefab "Boton"
     * Recibe el evento "RayHit" de la camara
     * En caso de activarse el botón, mueve el objeto "salida" a z:0
     * En caso de desactivarse el botón, devuelve el objeto "salida" a z:-500
     */
    public class BotonScript : MonoBehaviour
    {
        [SerializeField] private GameObject salida;
        [SerializeField] private GameObject modelo;
        
        private bool _activo;
        private Renderer _renderer;
        
        void Start()
        {
            _renderer = modelo.GetComponent<Renderer>();
            
            CameraScript.RayHit += AlternarBoton;
        }

        private void AlternarBoton(GameObject yo)
        {
            if (!yo.Equals(gameObject)) return;
            _activo = !_activo;
            var position = salida.transform.position;
            if (_activo)
            {
                MinijuegoProgGeneral.ActivarSalida(salida, position, _renderer, new []{0,2});
            }
            else
            {
                MinijuegoProgGeneral.DesactivarSalida(salida, position, _renderer, new []{0,2});
            }


        }
    }
}
