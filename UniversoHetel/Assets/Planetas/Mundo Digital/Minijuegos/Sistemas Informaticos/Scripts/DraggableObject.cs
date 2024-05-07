using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{

        public delegate void DragEndedDelegate(DraggableObject dragableObject);
        
        public DragEndedDelegate dragEndedCallback;
        
        
        
        private bool _isDragged = false;
        private Vector3 _mouseDragStartPosition;
        private Vector3 _objectDragStartPosition;
        private Vector3 _objectStartPosition;
        public bool alwaysTrue;

        private Quaternion _objectDragStartRotation;
        private ParticleSystem _particles;
        
        private Camera _camara;
        public Transform[] correctSnapPoint;
        public bool isCorrect = false;
        public bool isSnapped = false;
        public Transform snappedIntoPoint;
        private void Start()
        {
                if (alwaysTrue) isCorrect = true;
                _objectStartPosition = transform.localPosition;
                _camara = GameObject.Find("Main Camera").GetComponent<Camera>();
                _particles = GetComponent<ParticleSystem>();
        }

        private void OnMouseDown()
        {
                _isDragged = true;
                _mouseDragStartPosition = _camara.ScreenToWorldPoint(Input.mousePosition);
                _objectDragStartPosition = transform.localPosition;
                _objectDragStartRotation = transform.rotation;
                isSnapped = false;
                snappedIntoPoint = null;
                StopParticles();
                CancelInvoke(nameof(StopParticles));
        }

        private void OnMouseDrag()
        {
                if (_isDragged)
                {
                        transform.localPosition = _objectDragStartPosition +
                                                  (_camara.ScreenToWorldPoint(Input.mousePosition) -
                                                   _mouseDragStartPosition);
                }
        }

        private void OnMouseUp()
        {
                _isDragged = false;
                dragEndedCallback(this);
        }

        public void ReturnToOrigin()
        {
                transform.localPosition = _objectStartPosition;
                ReturnOriginalRotation();
        }

        private void ReturnOriginalRotation()
        {
                transform.rotation = _objectDragStartRotation;
        }

        public void StartParticles()
        { 
                _particles.Play();
                Invoke(nameof(StopParticles),5f);
        }

        public void StopParticles()
        { 
                _particles.Stop();
        }


}
