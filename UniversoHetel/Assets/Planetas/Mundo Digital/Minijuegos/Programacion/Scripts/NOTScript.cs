using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script del prefab "NOT" (!)
     * Detecta si su "Pata" está activa
     * En caso de que esté activada, dseactiva la salida
     * En caso de que esté desactivada, activa la salida
     * TODO: Cambiar la comprobación de un "InvokeRepeating" a eventos
     */
    public class NotScript : MonoBehaviour
    {
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject salida;
        [SerializeField] private GameObject modelo;
        
        private PataScript _pata1;
        private Renderer _renderer;
        
        void Start()
        {
            _pata1 = pata1Object.GetComponent<PataScript>();
            _renderer = modelo.GetComponent<Renderer>();
            
            InvokeRepeating(nameof(CheckPatas), 0f, 0.1f);
        }

        private void CheckPatas()
        {
            var position = salida.transform.position;
            if (!_pata1.GetActivo())
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
