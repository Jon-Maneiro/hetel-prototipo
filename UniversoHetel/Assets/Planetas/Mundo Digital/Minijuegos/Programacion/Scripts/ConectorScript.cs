using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Script de los prefabs "Conector", "Conector Fin", "Conector Ini" y "ConectorL"
     * Detecta si la "Pata" de entrada está activa
     * En caso de que esté activa, activa la salida
     * En casto de que esté desactivada, desactiva la salida
     * TODO: Cambiar la comprobación de un "InvokeRepeating" a eventos
     */
    public class ConectorScript : MonoBehaviour
    {
        [SerializeField] private GameObject entrada;
        [SerializeField] private GameObject salida;
        [SerializeField] private Renderer modelo;
        
        private PataScript _entrada;
        private Renderer _renderer;
        
        void Start()
        { 
            _entrada = entrada.GetComponent<PataScript>();
            _renderer = modelo.GetComponent<Renderer>();
            
            InvokeRepeating(nameof(CheckPatas), 0f, 0.01f);
        }
        
        private void CheckPatas()
        {
            var position = salida.transform.position;
            if (_entrada.GetActivo())
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
