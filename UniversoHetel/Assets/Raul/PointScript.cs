using System;
using UnityEngine;

namespace Raul
{
    public class PointScript : MonoBehaviour
    {
        public static event Action<GameObject> RayHit;
        [SerializeField] private LayerMask mask;
        private GameObject _nuevaCam;
        private Vector3 _originalPos;
        private Camera _cam;

        private void Start()
        {
            _cam = GetComponent<Camera>();
            _originalPos = transform.position;
            PlanetScript.MoveCamera += MoveCamera;
            PlanetScript.RestoreCamera += Restore;
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
            InvokeRepeating(nameof(Move), 0f, 0.002f);
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _nuevaCam.transform.position, 30 * Time.deltaTime);
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
    }
}
