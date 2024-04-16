using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    public class ConectorScript : MonoBehaviour
    {
    
        [SerializeField] private GameObject entradaObject;
        [SerializeField] private GameObject salidaObject;
        [SerializeField] private Renderer modelo;
        
        private PataScript _entrada;
        
        void Start()
        { 
            _entrada = entradaObject.GetComponent<PataScript>();
        }
        
        void Update()
        {
            var position = salidaObject.transform.position;
            if (_entrada.GetActivo())
            {
                position = new Vector3(position.x, position.y, 0);
                salidaObject.transform.position = position;
                foreach (var material in modelo.materials)
                {
                    material.color = Color.green;
                }
                
            }
            else
            {
                position = new Vector3(position.x, position.y, -500);
                salidaObject.transform.position = position;
                foreach (var material in modelo.materials)
                {
                    material.color = Color.red;
                }
            }
        }
    }
}
