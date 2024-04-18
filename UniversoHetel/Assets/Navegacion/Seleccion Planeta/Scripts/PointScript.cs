using System;
using UnityEngine;

namespace Raul
{
    public class PointScript : MonoBehaviour
    {
        public static event Action<GameObject> RayHit;
        public static event Action CamaraCerca;
        public static event Action CamaraLejos;
        public static event Action ActivaNave;
        
        [SerializeField] private LayerMask mask;
        
        private GameObject _nuevaCam;
        private Vector3 _originalPos;
        private Camera _cam;
        private bool _enPlaneta;

        private void Start()
        {
            PlanetScript.MoveCamera += MoveCamera;
            PlanetScript.RestoreCamera += Restore;
            
            _cam = GetComponent<Camera>();
            _originalPos = transform.position;
            _enPlaneta = false;
        }

        private void OnDestroy()
        {
            PlanetScript.MoveCamera -= MoveCamera;
            PlanetScript.RestoreCamera -= Restore;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, mask))
                {
                    RayHit?.Invoke(hit.transform.gameObject);
                }
            }
        }
        
        private void MoveCamera(GameObject position)
        {
            _nuevaCam = position;
            CancelInvoke(nameof(Move));
            CancelInvoke(nameof(RestorePosition));
            InvokeRepeating(nameof(CheckCamera), 0f, 0.01f);
            InvokeRepeating(nameof(Move), 0f, 0.001f);
        }

        private void Move()
        {
            if (_enPlaneta)
            {
                transform.position = Vector3.MoveTowards(transform.position, _nuevaCam.transform.position, 5 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _nuevaCam.transform.position, 30 * Time.deltaTime);
            }
            
        }

        private void Restore()
        {
            CancelInvoke(nameof(RestorePosition));
            CancelInvoke(nameof(Move));
            InvokeRepeating(nameof(RestorePosition), 0f, 0.01f);
        }

        private void RestorePosition()
        {
            transform.position = Vector3.MoveTowards(transform.position, _originalPos, 80 * Time.deltaTime);
        }

        private void CheckCamera()
        {
            if (Math.Abs(transform.position.z - _nuevaCam.transform.position.z) < 0.1f)
            {
                CamaraCerca?.Invoke();
                ActivaNave?.Invoke();
                _enPlaneta = true;
            }
            else
            {
                _enPlaneta = false;
            }
            
            if (Math.Abs(Vector3.Distance(transform.position, _nuevaCam.transform.position)) > 0.1f) {
                CamaraLejos?.Invoke();
            }
        }
    }
}
