using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script del prefab "NOT" (!)
     * Detecta si su "Pata" está activa
     * En caso de que esté activada, dseactiva la salida
     * En caso de que esté desactivada, activa la salida
     */
    public class NotScript : MonoBehaviour
    {
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject salida;
        [SerializeField] private GameObject modelo;
        
        private bool _pata;
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
            if (!pata.Equals(pata1Object)) return;
            _pata = true;
            CheckPatas();
        }
        
        private void PataDesactivo(GameObject pata)
        {
            if (!pata.Equals(pata1Object)) return;
            _pata = false;
            CheckPatas();
        }

        private void CheckPatas()
        {
            var position = salida.transform.position;
            if (!_pata)
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
