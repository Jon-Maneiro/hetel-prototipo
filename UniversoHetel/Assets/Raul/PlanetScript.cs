using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Raul
{
    public class PlanetScript : MonoBehaviour
    {
        public static event Action DesactivaTodos;
        public static event Action<GameObject> PlanetaActivo;
        public static event Action<GameObject> MoveCamera;
        public static event Action RestoreCamera;
        
        [SerializeField] private Scene escenaRelacionada;
        [SerializeField] private GameObject outline;
        [SerializeField] private GameObject sol;
        [SerializeField] private int speed;
        [SerializeField] private GameObject punto;
        [SerializeField] private GameObject canvas;
        
        private float _xAngle, _zAngle;
        private bool _seleccionado;
        private bool _agrandando;
        private bool _empequeneciendo;
        private float _repeatRate = 0.03f;
        private Vector3 _escala = new Vector3(0.02f, 0.02f, 0.02f);
        
        void Start()
        {
            CanvasManager.PulsadoNo += DesactivarSeleccionado;
            CanvasManager.PulsadoYes += MandarActivo;
            PointScript.RayHit += RayHit;
            PointScript.CamaraCerca += Activo;
            PointScript.CamaraLejos += Desactivo;
            DesactivaTodos += DesactivarSeleccionado;
            
            _xAngle = Random.Range(-0.5f, 0.5f);
            _zAngle = Random.Range(-0.5f, 0.5f);
            _seleccionado = false;
            _empequeneciendo = false;
            _agrandando = false;
            
            InvokeRepeating(nameof(Rotate), 0f, 0.01f);
        }

        private void Update()
        {
            GameObject o;
            (o = transform.parent.gameObject).transform.RotateAround(sol.transform.position, new Vector3(0f,0f,1), speed * Time.deltaTime);
            o.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        private void MandarActivo()
        {
            if (!_seleccionado) return;
            SceneManager.LoadScene(escenaRelacionada.name);
            PlanetaActivo?.Invoke(gameObject);
        }

        private void RayHit(GameObject hitObject)
        {
            if (!hitObject.Equals(gameObject)) return;
            if (_seleccionado) return;
            DesactivaTodos?.Invoke();
            ActivarSeleccionado();
        }

        private void ActivarSeleccionado()
        {
            if (_seleccionado) return;
            MoveCamera?.Invoke(punto);
            _seleccionado = true;
            StartCoroutine(nameof(Agrandar));
        }
        
        private void DesactivarSeleccionado()
        {
            if (!_seleccionado) return;
            RestoreCamera?.Invoke();
            Desactivo();
            _seleccionado = false;
            StartCoroutine(nameof(Empequenecer));
        }

        private void Activo()
        {
            if (!_seleccionado) return;
            outline.SetActive(true);
            canvas.SetActive(true);
        }

        private void Desactivo()
        {
            canvas.SetActive(false);
            outline.SetActive(false);
        }

        private IEnumerator Agrandar()
        {
            yield return new WaitUntil(() => !_empequeneciendo);
            _agrandando = true;
            InvokeRepeating(nameof(EscalarUp), 0f, _repeatRate);
            yield return new WaitUntil(() => Math.Abs(transform.localScale.x - 1.5f) < 0.05f);
            _agrandando = false;
            CancelInvoke(nameof(EscalarUp));
        }

        private IEnumerator Empequenecer()
        {
            yield return new WaitUntil(() => !_agrandando);
            _empequeneciendo = true;
            InvokeRepeating(nameof(EscalarDown), 0f, _repeatRate);
            yield return new WaitUntil(() => Math.Abs(transform.localScale.x - 1f) < 0.05f);
            _empequeneciendo = false;
            CancelInvoke(nameof(EscalarDown));
        }

        private void EscalarUp()
        {
            transform.localScale += _escala;
            outline.transform.localScale += _escala;
        }
        private void EscalarDown()
        {
            transform.localScale -= _escala;
            outline.transform.localScale -= _escala;
        }

        private void Rotate()
        {
            transform.Rotate(_xAngle, 1*Time.deltaTime, _zAngle, Space.Self);
        }
    }
}

