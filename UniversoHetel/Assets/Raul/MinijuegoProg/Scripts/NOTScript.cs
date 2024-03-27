using UnityEngine;

namespace Raul.scripts
{
    public class NotScript : MonoBehaviour
    {
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject salida;

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
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                position = new Vector3(position.x, position.y, -500);
                salida.transform.position = position;
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
