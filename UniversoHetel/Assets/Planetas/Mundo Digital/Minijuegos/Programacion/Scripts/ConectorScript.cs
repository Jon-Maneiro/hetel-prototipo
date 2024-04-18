using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script de los prefabs "Conector", "Conector Fin", "Conector Ini" y "ConectorL"
     * Detecta si la "Pata" de entrada está activa
     * En caso de que esté activa, activa la salida
     * En casto de que esté desactivada, desactiva la salida
     */
    public class ConectorScript : MonoBehaviour
    {
        [SerializeField] private GameObject entrada;
        [SerializeField] private GameObject salida;
        [SerializeField] private Renderer modelo;
        
        private bool _entrada;
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
            if (!pata.Equals(entrada)) return;
            _entrada = true;
            CheckPatas();
        }
        
        private void PataDesactivo(GameObject pata)
        {
            if (!pata.Equals(entrada)) return;
            _entrada = false;
            CheckPatas();
        }
        
        private void CheckPatas()
        {
            var position = salida.transform.position;
            if (_entrada)
            {
                MinijuegoProgGeneral.ActivarSalida(salida, position, _renderer,
                    _renderer.materials.Length == 1 ? new[] { 0 } : new[] { 0, 1 });
            }
            else
            {
                MinijuegoProgGeneral.DesactivarSalida(salida, position, _renderer,
                    _renderer.materials.Length == 1 ? new[] { 0 } : new[] { 0, 1 });
            }
        }
    }
}
