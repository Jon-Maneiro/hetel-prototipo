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

        private Camera _camara;
        public Transform[] correctSnapPoint;
        public bool isCorrect = false;
        private void Start()
        {
                if (alwaysTrue) isCorrect = true;
                _objectStartPosition = transform.localPosition;
                _camara = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        private void OnMouseDown()
        {
                _isDragged = true;
                _mouseDragStartPosition = _camara.ScreenToWorldPoint(Input.mousePosition);
                _objectDragStartPosition = transform.localPosition;
                _objectDragStartRotation = transform.rotation;
                Rotate();
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

        private void Rotate()
        {
                //transform.Rotate(new Vector3(-90,0,90));
        }

        private void ReturnOriginalRotation()
        {
                transform.rotation = _objectDragStartRotation;
        }




}
