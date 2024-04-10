using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TubeScript : MonoBehaviour
{

    private float[] rotations = { 0, 90, 180, 270};
    [SerializeField] private float[] correctRotation;
    [SerializeField] private bool isPlaced = false;
    [SerializeField] private bool notRotate = false;
    private int _possibleRotation = 0;

    private TubeGameControllerScript _tubeGameControllerScript;

    private void Awake()
    {
        _tubeGameControllerScript = GameObject.Find("TubeGameController").GetComponent<TubeGameControllerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _possibleRotation = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        if (!notRotate)  transform.eulerAngles = new Vector3(0,0,rotations[rand]); 
        CheckCorrectRotation();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatePiece()
    {
        transform.Rotate(new Vector3(0f,0f,90f), Space.Self);
        CheckCorrectRotation();
    }

    private void CheckCorrectRotation()
    {
        bool correct = false;

        if (_possibleRotation == 0) return;
        
        if (_possibleRotation > 1)
        {
            foreach (var rotation in correctRotation)
            {
                if (Math.Abs(transform.eulerAngles.z - rotation) < 1)
                {
                    correct = true;
                }
            }
            if (correct)
            {
                if (!isPlaced)
                {
                    isPlaced = true;
                    _tubeGameControllerScript.CorrectMove();    
                    GetComponentInChildren<Renderer>().material.color = Color.green;
                }
            }
            else
            {
                if (isPlaced)
                {
                    isPlaced = false;
                    _tubeGameControllerScript.WrongMove();    
                    GetComponentInChildren<Renderer>().material.color = Color.white;
                }
            }
                
        }
        else
        {
            if (Math.Abs(transform.eulerAngles.z - correctRotation[0]) < 1)
            {
                if (!isPlaced)
                {
                    isPlaced = true;
                    _tubeGameControllerScript.CorrectMove();
                    GetComponentInChildren<Renderer>().material.color = Color.green;

                }
            }
            else
            {
                if (isPlaced)
                {
                    isPlaced = false;
                    _tubeGameControllerScript.WrongMove();    
                    GetComponentInChildren<Renderer>().material.color = Color.white;

                }
            }
        }
    }
}
