using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    public class OrScript : MonoBehaviour
    {
        
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject pata2Object;
        [SerializeField] private GameObject salida;
        //[SerializeField] private GameObject modelo;
        
        private PataScript _pata1, _pata2;
        
        void Start()
        {
            _pata1 = pata1Object.GetComponent<PataScript>();
            _pata2 = pata2Object.GetComponent<PataScript>();
        }
        
        void Update()
        {
            var position = salida.transform.position;
            if (_pata1.GetActivo() || _pata2.GetActivo())
            {
                position = new Vector3(position.x, position.y, 0);
                salida.transform.position = position;
                //GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                position = new Vector3(position.x, position.y, -500);
                salida.transform.position = position;
                //GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
