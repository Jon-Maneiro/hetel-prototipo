using UnityEngine;

namespace Raul.scripts
{
    public class ConectorScript : MonoBehaviour
    {
    
        [SerializeField] private GameObject entradaObject;
        [SerializeField] private GameObject salidaObject;
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
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                position = new Vector3(position.x, position.y, -500);
                salidaObject.transform.position = position;
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
