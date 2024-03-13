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
    private int _possibleRotation = 0;

    private TubeGameControllerScript _tubeGameControllerScript;

    private void Awake()
    {
        _tubeGameControllerScript = GameObject.Find("TubeGameController").GetComponent<TubeGameControllerScript>()
    }

    // Start is called before the first frame update
    void Start()
    {
        _possibleRotation = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0,0,rotations[rand]);
        Debug.Log(correctRotation.Length);
        CheckCorrectRotation();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatePiece()
    {
        transform.Rotate(new Vector3(0f,0f,-90f), Space.Self);
        CheckCorrectRotation();
    }

    private void CheckCorrectRotation()
    {
        if (_possibleRotation == 0) return;
        
        if (_possibleRotation > 1)
        {
            if (Math.Abs(transform.eulerAngles.z - correctRotation[0]) < 1 ||
                Math.Abs(transform.eulerAngles.z - correctRotation[1]) < 1)
            {
                isPlaced = true;
                _tubeGameControllerScript.CorrectMove();
            }
            else
            {
                isPlaced = false;
                _tubeGameControllerScript.WrongMove();
            }
                
        }
        else
        {
            if (Math.Abs(transform.eulerAngles.z - correctRotation[0]) < 1)
            {
                isPlaced = true;
                _tubeGameControllerScript.CorrectMove();
            }
            else
            {
                isPlaced = false;
                _tubeGameControllerScript.WrongMove();
            }
        }
    }
}
