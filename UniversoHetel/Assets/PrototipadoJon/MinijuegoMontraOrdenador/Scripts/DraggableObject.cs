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

        public Transform[] correctSnapPoint;
        public bool isCorrect = false;
        private void Start()
        {
                if (alwaysTrue) isCorrect = true;
                _objectStartPosition = transform.localPosition;
        }

        private void OnMouseDown()
        {
                _isDragged = true;
                _mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _objectDragStartPosition = transform.localPosition;
        }

        private void OnMouseDrag()
        {
                if (_isDragged)
                {
                        transform.localPosition = _objectDragStartPosition +
                                                  (Camera.main.ScreenToWorldPoint(Input.mousePosition) -
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
        }
}
