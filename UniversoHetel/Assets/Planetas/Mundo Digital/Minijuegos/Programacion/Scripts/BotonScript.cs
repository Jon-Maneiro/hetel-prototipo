using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
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
            var position = salida.transform.position;
            if (_activo)
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
