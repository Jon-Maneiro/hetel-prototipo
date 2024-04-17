using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    public class NotScript : MonoBehaviour
    {
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject salida;
        [SerializeField] private GameObject modelo;
        
        private PataScript _pata1;
        void Start()
        {
            _pata1 = pata1Object.GetComponent<PataScript>();
        }

        void Update()
        {
            var position = salida.transform.position;
            if (!_pata1.GetActivo())
            {
                position = new Vector3(position.x, position.y, 0);
                salida.transform.position = position;
                modelo.GetComponent<Renderer>().materials[1].color = Color.green;
            }
            else
            {
                position = new Vector3(position.x, position.y, -500);
                salida.transform.position = position;
                modelo.GetComponent<Renderer>().materials[1].color = Color.red;
            }
        }
    }
}
