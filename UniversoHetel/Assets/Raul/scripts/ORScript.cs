using UnityEngine;

namespace Raul.scripts
{
    public class OrScript : MonoBehaviour
    {
        
        [SerializeField] private GameObject pata1Object;
        [SerializeField] private GameObject pata2Object;
        [SerializeField] private GameObject salida;

        private PataScript _pata1, _pata2;
        
        // Start is called before the first frame update
        void Start()
        {
            _pata1 = pata1Object.GetComponent<PataScript>();
            _pata2 = pata2Object.GetComponent<PataScript>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_pata1.GetActivo() || _pata2.GetActivo())
            {
                salida.transform.position = new Vector3(salida.transform.position.x, salida.transform.position.y, 0);
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                salida.transform.position = new Vector3(salida.transform.position.x, salida.transform.position.y, -500);
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
