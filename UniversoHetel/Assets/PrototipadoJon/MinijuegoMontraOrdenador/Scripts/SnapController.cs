using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SnapController : MonoBehaviour
{

    //Funcionalidad DragAndDrop https://www.youtube.com/watch?v=axW46wCJxZ0
    
    public List<Transform> snapPoints;
    public List<DraggableObject> draggableObjects;
    public float snapRange = 0.5f;
    public int neededComponents;
    public Canvas canvasVictoria;
    public Canvas canvasDerrota;
    public float remainingTime = 120;
    [SerializeField] private TextMeshProUGUI temporizador; 
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (DraggableObject draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
        InvokeRepeating(nameof(TimerFunction), 0f, 0.03f);
    }
    
    private void TimerFunction()
    {
        remainingTime -= Time.deltaTime;
        temporizador.text = remainingTime.ToString();
        if (remainingTime <= 0.0f)
        {
            CancelInvoke(nameof(TimerFunction));
            canvasDerrota.enabled = true;
            Invoke(nameof(changeScene),2f);
        }
    }
    
    private void OnDragEnded(DraggableObject draggableObject)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggableObject.transform.localPosition,
                                            snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggableObject.transform.localPosition = closestSnapPoint.localPosition;
            CheckCorrectPosition(draggableObject,closestSnapPoint);
        }
        else
        {
            draggableObject.ReturnToOrigin();
        }

    }

    private void CheckCorrectPosition(DraggableObject draggableObject, Transform snapPoint)
    {
        if (snapPoint.Equals(draggableObject.correctSnapPoint))
        {
            draggableObject.isCorrect = true;
        }

        foreach (DraggableObject draggable in draggableObjects)
        {
            if (!draggable.isCorrect) return;
        }

        canvasVictoria.enabled = true;
        Invoke(nameof(changeScene), 2f);
    }

    private void changeScene()
    {
        //Irse de esta escena a la anterior
    }

}
