using UnityEngine;

namespace Raul.scripts
{
    public class BotonScript : MonoBehaviour
    {
        
        [SerializeField] private GameObject salida;
        private bool _activo;
    
        void Start()
        {
            salida.SetActive(true);
            CameraScript.RayHit += AlternarBoton;
        }

        private void AlternarBoton(GameObject yo)
        {
            if (yo.Equals(gameObject))
            {
                _activo = !_activo;
            }
        }
    
        void Update()
        {
            if (_activo)
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
