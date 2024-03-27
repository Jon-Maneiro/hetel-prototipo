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
            if (_entrada.GetActivo())
            {
                salidaObject.transform.position = new Vector3(salidaObject.transform.position.x,
                    salidaObject.transform.position.y, 0);
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                salidaObject.transform.position = new Vector3(salidaObject.transform.position.x,
                    salidaObject.transform.position.y, -500);
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
